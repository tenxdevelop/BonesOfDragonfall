/**************************************************************************\
   Copyright SunWorldStudio Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Reactive;
using SkyForge.Proxy;

namespace BonesOfDragonfall
{
    public interface IInventoryModel : IProxy<InventoryData>
    {
        int OwnerId { get; }

        ReactiveProperty<float> MaxWeight { get; }
        ReactiveCollection<IItemModel> Items { get; }
    }
}