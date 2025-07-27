/**************************************************************************\
   Copyright SunWorldStudio Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Reactive.Extension;
using SkyForge.Reactive;
using System.Linq;
using System;

namespace BonesOfDragonfall
{
    public class InventoryModel : IInventoryModel
    {
        public event Action InventoryChangedEvent;
        public int OwnerId => OriginState.ownerId;
        public InventoryData OriginState { get; private set; }

        public ReactiveProperty<float> MaxWeight { get; private set; }
        public ReactiveCollection<IItemModel> Items { get; private set; }

        private IItemFactoryService _itemFactoryService;
        public InventoryModel(InventoryData originState, IItemFactoryService itemFactoryService)
        {
            _itemFactoryService = itemFactoryService;
            OriginState = originState;

            MaxWeight = new ReactiveProperty<float>(originState.maxWeight);
            MaxWeight.Subscribe(newMaxWeight => OriginState.maxWeight = newMaxWeight);
            
            UpdateInventory(originState);
        }

        public void InventoryChanged()
        {
            InventoryChangedEvent?.Invoke();
        }
        
        private void UpdateInventory(InventoryData originState)
        {
            Items = new ReactiveCollection<IItemModel>();
            
            foreach (var item in originState.items)
            {
                var itemModel = _itemFactoryService.CreateItemModel(item.itemId);
                itemModel.Amount.Value = item.amount;
                
                Items.Add(itemModel);
            }

            Items.Subscribe(OnItemsAdded, OnItemsRemoved, OnItemsClear);
        }
        
        private void OnItemsClear()
        {
            OriginState.items.Clear();
        }
        private void OnItemsRemoved(IItemModel removedItem)
        {
            var itemData = _itemFactoryService.GetItemData(removedItem);
            var removedItemData = OriginState.items.FirstOrDefault(itemData => itemData.Equals(itemData));
            OriginState.items.Remove(removedItemData);
        }
        private void OnItemsAdded(IItemModel newItem)
        {
            var itemData = _itemFactoryService.GetItemData(newItem);
            OriginState.items.Add(itemData);
        }
    }
}