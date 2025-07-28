/**************************************************************************\
   Copyright SunWorldStudio Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Reactive;

namespace BonesOfDragonfall
{
    public interface IMagicEntity
    {
        ReactiveProperty<float> MagicPoint { get; }

        ReactiveProperty<float> MaxMagicPoint { get; }
        ReactiveCollection<MagicElementData> MagicCast { get; }
    }
}