/**************************************************************************\
   Copyright SunWorldStudio Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Reactive;
using SkyForge.MVVM;

namespace BonesOfDragonfall
{
    public interface IUIItemParamViewModel : IViewModel
    {
        ReactiveProperty<string> ParamsName { get; }
        ReactiveProperty<float> ParamsValue { get; }
    }
}