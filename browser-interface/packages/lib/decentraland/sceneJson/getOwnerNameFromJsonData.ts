import { Scene } from '@dcl/schemas'

export function getOwnerNameFromJsonData(jsonData?: Scene) {
  let ownerName = jsonData?.contact?.name
  if (ownerName === 'author-name') {
    // avoid using autogenerated name
    ownerName = undefined
  }

  return ownerName || 'Unknown'
}