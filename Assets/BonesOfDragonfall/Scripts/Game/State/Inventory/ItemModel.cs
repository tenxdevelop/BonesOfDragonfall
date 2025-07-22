/**************************************************************************\
   Copyright SunWorldStudio Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Reactive.Extension;
using SkyForge.Reactive;
using SkyForge.Proxy;

namespace BonesOfDragonfall
{
    public abstract class ItemModel<TItemData> : IItemModel, IProxy<TItemData> where  TItemData : ItemData
    {
        public int ItemId => OriginState.itemId;
        public TItemData OriginState { get; private set; }
        
        public ReactiveProperty<int> Amount { get; private set; }

        public ItemModel(TItemData originState)
        {
            OriginState = originState;
            
            Amount = new ReactiveProperty<int>(originState.amount);
            Amount.Subscribe(newAmount => originState.amount = newAmount);
        }
    }
}