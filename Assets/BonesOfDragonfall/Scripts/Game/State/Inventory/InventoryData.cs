/**************************************************************************\
   Copyright SunWorldStudio Corporation. All Rights Reserved.
\**************************************************************************/

using System.Collections.Generic;
using System;

namespace BonesOfDragonfall
{
    [Serializable]
    public class InventoryData
    {
        public int ownerId;

        public float maxWeight;
        
        public List<ItemData> items;
    }
}