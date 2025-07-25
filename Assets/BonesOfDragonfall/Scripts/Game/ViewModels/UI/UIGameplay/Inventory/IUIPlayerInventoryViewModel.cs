/**************************************************************************\
   Copyright SunWorldStudio Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Reactive;
using SkyForge.MVVM;

namespace BonesOfDragonfall
{
    public interface IUIPlayerInventoryViewModel : IViewModel
    {
        ReactiveCollection<IViewModel> Items { get; }
        ReactiveProperty<bool> IsActiveInventory { get; }
    }
}