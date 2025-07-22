/**************************************************************************\
   Copyright SunWorldStudio Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Reactive;

namespace BonesOfDragonfall
{
    public interface IGameConfigProvider : System.IDisposable
    {
        GameConfig GameConfig { get; }

        IObservable<GameConfig> LoadGameConfig();
    }
}