import { AnyAction } from 'redux'
import { fork, put, race, select, take, takeEvery, takeLatest } from 'redux-saga/effects'

import { PARCEL_LOADING_STARTED, RENDERER_INITIALIZED_CORRECTLY } from 'shared/renderer/types'
import { AUTHENTICATE, ChangeLoginStateAction, CHANGE_LOGIN_STAGE, SIGNUP_SET_IS_SIGNUP } from 'shared/session/actions'
import { trackEvent } from '../analytics'
import { lastPlayerPosition } from '../world/positionThings'

import { getAssetBundlesBaseUrl } from 'config'
import { LoginState } from 'kernel-web-interface'
import { now } from 'lib/javascript/now'
import { call } from 'redux-saga-test-plan/matchers'
import { getSelectedNetwork } from 'shared/dao/selectors'
import { getResourcesURL } from 'shared/location'
import { SET_REALM_ADAPTER } from 'shared/realm/actions'
import { POSITION_SETTLED, POSITION_UNSETTLED, SET_SCENE_LOADER } from 'shared/scene-loader/actions'
import { onLoginCompleted } from 'shared/session/onLoginCompleted'
import { getCurrentUserId } from 'shared/session/selectors'
import { RootState } from 'shared/store/rootTypes'
import { LoadableScene } from 'shared/types'
import { loadedSceneWorkers } from 'shared/world/parcelSceneManager'
import { SceneWorkerReadyState } from 'shared/world/SceneWorker'
import {
  informPendingScenes,
  PENDING_SCENES,
  SceneFail,
  SceneLoad,
  SCENE_CHANGED,
  SCENE_FAIL,
  SCENE_LOAD,
  SCENE_START,
  SCENE_UNLOAD,
  UPDATE_STATUS_MESSAGE
} from './actions'
import { experienceStarted, metricsAuthSuccessful, metricsUnityClientLoaded, TELEPORT_TRIGGERED } from './types'

export function* loadingSaga() {
  yield takeEvery(SCENE_LOAD, trackLoadTime)
  yield takeEvery(SCENE_FAIL, reportFailedScene)

  yield fork(translateActions)
  yield fork(initialSceneLoading)

  yield takeLatest([SCENE_FAIL, SCENE_LOAD, SCENE_START, SCENE_CHANGED], handleReportPendingScenes)
}

function* reportFailedScene(action: SceneFail) {
  const { id, baseUrl } = action.payload
  const fullRootUrl = getResourcesURL('.')

  trackEvent('scene_loading_failed', {
    sceneId: id,
    contentServer: baseUrl,
    contentServerBundles: getAssetBundlesBaseUrl(yield select(getSelectedNetwork)) + '/',
    rootUrl: fullRootUrl
  })
}

function* translateActions() {
  yield takeEvery(RENDERER_INITIALIZED_CORRECTLY, triggerUnityClientLoaded)
  yield takeEvery(CHANGE_LOGIN_STAGE, triggerAuthSuccessful)
}

function* triggerAuthSuccessful(action: ChangeLoginStateAction) {
  if (action.payload.stage === LoginState.COMPLETED) {
    yield put(metricsAuthSuccessful())
  }
}

function* triggerUnityClientLoaded() {
  yield put(metricsUnityClientLoaded())
}

export function* trackLoadTime(action: SceneLoad): any {
  const start = now()
  const { id } = action.payload
  const entityId = id
  const result = yield race({
    start: take(
      (action: AnyAction) => action.type === SCENE_START && (action.payload as LoadableScene).id === entityId
    ),
    fail: take((action: AnyAction) => action.type === SCENE_FAIL && (action.payload as LoadableScene).id === entityId)
  })
  const userId = yield select(getCurrentUserId)
  const position = lastPlayerPosition
  trackEvent('SceneLoadTimes', {
    position: { ...position },
    elapsed: now() - start,
    success: !!result.start,
    sceneId: entityId,
    userId: userId
  })
}

export const ACTIONS_FOR_LOADING = [
  AUTHENTICATE,
  CHANGE_LOGIN_STAGE,
  PARCEL_LOADING_STARTED,
  PENDING_SCENES,
  RENDERER_INITIALIZED_CORRECTLY,
  SCENE_FAIL,
  SCENE_LOAD,
  SIGNUP_SET_IS_SIGNUP,
  TELEPORT_TRIGGERED,
  UPDATE_STATUS_MESSAGE,
  SET_REALM_ADAPTER,
  SET_SCENE_LOADER,
  POSITION_SETTLED,
  POSITION_UNSETTLED,
  SCENE_UNLOAD
]

function* waitForSceneLoads() {
  function shouldWaitForScenes(state: RootState) {
    if (!state.renderer.parcelLoadingStarted) {
      return true
    }

    // in the initial load, we should wait until we have *some* scene to load
    if (state.loading.initialLoad) {
      if (state.loading.pendingScenes !== 0 || state.loading.totalScenes === 0) {
        return true
      }
    }

    // otherwise only wait until pendingScenes == 0
    return state.loading.pendingScenes !== 0
  }

  while (yield select(shouldWaitForScenes)) {
    // these are the events that _may_ change the result of shouldWaitForScenes
    yield take(ACTIONS_FOR_LOADING)
  }
}

function* initialSceneLoading() {
  yield call(onLoginCompleted)
  yield call(waitForSceneLoads)
  yield put(experienceStarted())
}

/**
 * Reports the number of loading parcel scenes to unity to handle the loading states
 */
function* handleReportPendingScenes() {
  const pendingScenes = new Set<string>()

  let countableScenes = 0
  for (const [sceneId, sceneWorker] of loadedSceneWorkers) {
    const isPending = (sceneWorker.ready & SceneWorkerReadyState.STARTED) === 0
    const failedLoading = (sceneWorker.ready & SceneWorkerReadyState.LOADING_FAILED) !== 0

    countableScenes++

    if (isPending && !failedLoading) {
      pendingScenes.add(sceneId)
    }
  }

  yield put(informPendingScenes(pendingScenes.size, countableScenes))
}