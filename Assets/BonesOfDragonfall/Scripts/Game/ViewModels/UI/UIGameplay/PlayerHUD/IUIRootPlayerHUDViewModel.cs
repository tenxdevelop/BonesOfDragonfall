/**************************************************************************\
   Copyright SunWorldStudio Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Reactive;
using SkyForge.MVVM;

namespace BonesOfDragonfall
{
    public interface IUIRootPlayerHUDViewModel : IViewModel
    {
        ReactiveProperty<float> MaxHealthPoints { get; }
        
        ReactiveProperty<float> CurrentHealthPoints { get; }

        ReactiveProperty<float> MaxMagicPoints { get; }
        
        ReactiveProperty<float> CurrentMagicPoints { get; }
    }
}