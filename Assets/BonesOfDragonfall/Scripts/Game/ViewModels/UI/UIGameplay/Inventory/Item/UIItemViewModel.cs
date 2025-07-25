/**************************************************************************\
   Copyright SunWorldStudio Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Reactive;
using UnityEngine;

namespace BonesOfDragonfall
{
    public class UIItemViewModel  : IUIItemViewModel
    {
        public int ItemId => _itemModel.ItemId;
        
        public ReactiveCollection<IUIItemParamViewModel> Params { get; }
        public ReactiveProperty<string> ItemName { get; private set; }
        
        public ReactiveProperty<Sprite> ItemSprite { get; private set; }
        public ReactiveProperty<string> ItemDescription { get; private set; }
        public ReactiveProperty<ItemCategory> ItemCategory { get; private set; }
        public ReactiveProperty<float> ItemPrice { get; private set; }
        public ReactiveProperty<float> ItemWeight { get; private set; }
        
        public ReactiveProperty<int> ItemAmount => _itemModel.Amount;

        private readonly IItemModel _itemModel;
        
        public UIItemViewModel(IItemModel itemModel, ItemConfig itemConfig)
        {
            _itemModel = itemModel;
            ItemName = new ReactiveProperty<string>(itemConfig.nameLID);
            ItemDescription = new ReactiveProperty<string>(itemConfig.descriptionLID);
            ItemCategory = new ReactiveProperty<ItemCategory>(itemConfig.itemCategory);
            ItemPrice = new ReactiveProperty<float>(itemConfig.price);
            ItemWeight = new ReactiveProperty<float>(itemConfig.weight);
        }
        
        public void Dispose()
        {
            
        }

        public void Update(float deltaTime)
        {
            
        }

        public void PhysicsUpdate(float deltaTime)
        {
            
        }
        
    }
}