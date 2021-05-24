﻿using System.Collections.Generic;
using UnityEngine;

namespace DCL.Controllers
{
    public interface IBlockerInstanceHandler
    {
        void DestroyAllBlockers();
        Dictionary<Vector2Int, IPoolableObject> GetBlockers();
        void HideBlocker(Vector2Int coords, bool instant = false);
        void ShowBlocker(Vector2Int pos, bool instant = false);
        void SetParent(Transform parent);
    }
}