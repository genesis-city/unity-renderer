﻿using DCL.Controllers;
using DCL.Models;
using UnityEngine;

namespace DCL.Components
{
    public abstract class BaseShape : BaseDisposable
    {
        [System.Serializable]
        public class Model
        {
            public bool withCollisions = false;
            public bool visible = true;
        }

        public BaseShape(ParcelScene scene) : base(scene)
        {
        }

        public override void AttachTo(DecentralandEntity entity, System.Type overridenAttachedType = null)
        {
            if (attachedEntities.Contains(entity))
            {
                return;
            }

            base.AttachTo(entity, typeof(BaseShape));
            entity.currentShape = this;
        }

        public override void DetachFrom(DecentralandEntity entity, System.Type overridenAttachedType = null)
        {
            if (!attachedEntities.Contains(entity))
            {
                return;
            }

            // We do this instead of OnDetach += because it is required to run after every OnDetach listener
            entity.currentShape = null;

            base.DetachFrom(entity, typeof(BaseShape));
        }

        public static void ConfigureColliders(GameObject meshGameObject, bool hasCollision,
            bool filterByColliderName = false)
        {
            if (meshGameObject == null)
            {
                return;
            }

            MeshCollider collider;
            MeshRenderer renderer;
            MeshFilter[] meshFilters = meshGameObject.GetComponentsInChildren<MeshFilter>();

            for (int i = 0; i < meshFilters.Length; i++)
            {
                if (filterByColliderName)
                {
                    if (!meshFilters[i].transform.parent.name.ToLower().Contains("_collider"))
                    {
                        continue;
                    }

                    renderer = meshFilters[i].GetComponent<MeshRenderer>();

                    if (renderer != null)
                    {
                        renderer.enabled = false;
                        GameObject.Destroy(renderer);
                    }

                    meshFilters[i].gameObject.AddComponent<MeshCollider>().sharedMesh = meshFilters[i].sharedMesh;
                }
                else
                {
                    collider = meshFilters[i].GetComponent<MeshCollider>();

                    if (hasCollision)
                    {
                        if (collider == null)
                        {
                            collider = meshFilters[i].gameObject.AddComponent<MeshCollider>();
                        }
                        else if (!collider.enabled)
                        {
                            collider.enabled = true;
                        }

                        collider.sharedMesh = meshFilters[i].sharedMesh;
                    }
                    else if (collider != null && collider.enabled)
                    {
                        collider.enabled = false;
                    }
                }
            }
        }

        public static void ConfigureVisibility(GameObject meshGameObject, bool isVisible)
        {
            if (meshGameObject == null)
            {
                return;
            }
            
            if (!isVisible)
            {
                MaterialTransitionController[] materialTransitionControllers = meshGameObject.GetComponentsInChildren<MaterialTransitionController>();
                
                for (var i = 0; i < materialTransitionControllers.Length; i++)
                {
                    GameObject.Destroy(materialTransitionControllers[i]);
                }
            }

            Renderer[] renderers = meshGameObject.GetComponentsInChildren<Renderer>(true);
            Collider onClickCollider;
            int onClickLayer = LayerMask.NameToLayer("OnClick");

            for (var i = 0; i < renderers.Length; i++)
            {
                renderers[i].enabled = isVisible;
                
                if(renderers[i].transform.childCount > 0)
                {
                    onClickCollider = renderers[i].transform.GetChild(0).GetComponent<Collider>();

                    if(onClickCollider != null && onClickCollider.gameObject.layer == onClickLayer)
                        onClickCollider.enabled = isVisible;
                }
            }
        }
    }
}
