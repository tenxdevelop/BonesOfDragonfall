/**************************************************************************\
   Copyright SunWorldStudio Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Reactive;
using SkyForge.MVVM;

namespace BonesOfDragonfall
{
    public interface IUIRootPlayerHUDViewModel : IViewModel
    {
        ReactiveProperty<bool> IsActiveMagicHUD { get; }
        ReactiveCollection<MagicElementData> MagicCast { get; }
        ReactiveProperty<float> MaxHealthPoints { get; }
        
        ReactiveProperty<float> CurrentHealthPoints { get; }

        ReactiveProperty<float> MaxMagicPoints { get; }
        
        ReactiveProperty<float> CurrentMagicPoints { get; }

        void ShowMagicHUD();
        void HideMagicHUD();
    }
}