/**************************************************************************\
   Copyright SunWorldStudio Corporation. All Rights Reserved.
\**************************************************************************/

using UnityEngine;

namespace BonesOfDragonfall
{
    [CreateAssetMenu(fileName = "New item config", menuName = "Game configs/Inventory/new item config")]
    public class ItemConfig : ScriptableObject
    {
        public int itemId;
        
        public ItemType itemType;
        public ItemCategory itemCategory;
        
        public string iconSpriteId;
        public string prefabItemId;
        
        public string nameLID;
        public string descriptionLID;
        
        public float price;
        public float weight;
    }
}