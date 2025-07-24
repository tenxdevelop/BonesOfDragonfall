/**************************************************************************\
   Copyright SunWorldStudio Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Reactive;

namespace BonesOfDragonfall
{
    public interface ISettingsProvider : System.IDisposable
    {
        GameSettings GameSettings { get; }
        
        ApplicationSettings ApplicationSettings { get; }

        IObservable<GameSettings> LoadGameSettings();
    }
}