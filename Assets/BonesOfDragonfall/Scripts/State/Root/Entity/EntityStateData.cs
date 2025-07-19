/**************************************************************************\
   Copyright SunWorldStudio Corporation. All Rights Reserved.
\**************************************************************************/

using UnityEngine;
using System;

namespace BonesOfDragonfall
{
    [Serializable]
    public class EntityStateData
    {
        public int uniqueId;
        public string configId;
        public EntityType entityType;
        public Vector3 position;
    }
}