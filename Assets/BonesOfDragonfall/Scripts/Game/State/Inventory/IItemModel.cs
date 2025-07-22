/**************************************************************************\
   Copyright SunWorldStudio Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Reactive;

namespace BonesOfDragonfall
{
    public interface IItemModel
    {
        int ItemId { get; }
        ReactiveProperty<int> Amount { get; }
    }
}