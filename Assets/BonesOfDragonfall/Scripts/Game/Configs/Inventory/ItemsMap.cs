/**************************************************************************\
   Copyright SunWorldStudio Corporation. All Rights Reserved.
\**************************************************************************/

using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BonesOfDragonfall
{
    [CreateAssetMenu(fileName = "New item map", menuName = "Game configs/Inventory/new item map")]
    public class ItemsMap : ScriptableObject
    {
        public List<ItemConfig> Items;

        public ItemConfig GetItemConfig(int itemId)
        {
            var itemConfig = Items.FirstOrDefault(itemConfig => itemConfig.itemId.Equals(itemId));
            return itemConfig;
        }
    }
}