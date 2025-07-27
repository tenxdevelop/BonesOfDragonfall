/**************************************************************************\
   Copyright SunWorldStudio Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Reactive;
using SkyForge.Proxy;
using System;

namespace BonesOfDragonfall
{
    public interface IInventoryModel : IProxy<InventoryData>
    {
        event Action InventoryChangedEvent;
        int OwnerId { get; }
        ReactiveProperty<float> MaxWeight { get; }
        ReactiveCollection<IItemModel> Items { get; }
        void InventoryChanged();
    }
}