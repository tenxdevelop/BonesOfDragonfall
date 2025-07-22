/**************************************************************************\
   Copyright SunWorldStudio Corporation. All Rights Reserved.
\**************************************************************************/

using System;

namespace BonesOfDragonfall
{
    public class ItemFactoryService : IItemFactoryService
    {
        private ItemsMap _itemsConfigMap;

        public ItemFactoryService(IGameConfigProvider gameConfigProvider)
        {
            _itemsConfigMap = gameConfigProvider.GameConfig.ItemsMap;
        }
        
        public IItemModel CreateItemModel(int itemId)
        {
            var itemConfig = GetItemConfig(itemId);
            
            switch (itemConfig.itemType)
            {
                case ItemType.Resource:
                    var itemResourceModel = CreateItemResource(itemConfig);
                    return itemResourceModel;
                default:
                    throw new NotImplementedException($"not implemented create factory method for entity type: {itemConfig.itemType}");
            }
        }

        public ItemData GetItemData(IItemModel itemModel)
        {
            var itemConfig = GetItemConfig(itemModel.ItemId);

            switch (itemConfig.itemType)
            {
                case ItemType.Resource:
                    var resourceItemModel = itemModel as ResourceItemModel;
                    return resourceItemModel.OriginState;
                default:
                    throw new NotImplementedException($"not implemented get item state factory method for item type: {itemConfig.itemType}");
            }
        }

        public void Dispose()
        {
            
        }

        private IItemModel CreateItemResource(ItemConfig itemConfig)
        {
            var resourceItemData = new ResourceItemData()
            {
                itemId = itemConfig.itemId,
                amount = 0
            };
            
            var resourceItemModel = new ResourceItemModel(resourceItemData);
            return resourceItemModel;
        }

        private ItemConfig GetItemConfig(int itemId)
        {
            var itemConfig = _itemsConfigMap.GetItemConfig(itemId);
            
            if (itemConfig is null)
                throw new ArgumentNullException($"don't have item config for itemId: {itemId}");
            
            return itemConfig;
        }
    }
}