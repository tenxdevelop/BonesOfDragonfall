/**************************************************************************\
   Copyright SunWorldStudio Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Reactive;
using SkyForge.MVVM;
using UnityEngine;

namespace BonesOfDragonfall
{
    public interface IUIItemViewModel : IViewModel
    {
        int ItemId { get; }
        ReactiveCollection<IUIItemParamViewModel> Params { get; }

        ReactiveProperty<string> ItemName { get; }
        ReactiveProperty<Sprite> ItemSprite { get; }
        ReactiveProperty<string> ItemDescription { get; }
        ReactiveProperty<ItemCategory> ItemCategory { get; }
        ReactiveProperty<float> ItemPrice { get; }
        ReactiveProperty<float> ItemWeight { get; }
        ReactiveProperty<int> ItemAmount { get; }
    }
}