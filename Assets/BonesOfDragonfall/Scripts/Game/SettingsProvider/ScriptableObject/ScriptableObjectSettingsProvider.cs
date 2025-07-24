/**************************************************************************\
   Copyright SunWorldStudio Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Reactive.Extension;
using SkyForge.Reactive;
using UnityEngine;

namespace BonesOfDragonfall
{
    public class ScriptableObjectSettingsProvider : ISettingsProvider
    {
        public const string GAME_SETTINGS_NAME = "Settings/GameSettings";
        
        private const string APPLICATION_SETTINGS_NAME = "Settings/ApplicationSettings";
        public GameSettings GameSettings { get; private set; }
        
        public ApplicationSettings ApplicationSettings { get; private set; }
        
        private string _settingsName;
        
        public ScriptableObjectSettingsProvider(string settingsName)
        {
            ApplicationSettings = Resources.Load<ApplicationSettings>(APPLICATION_SETTINGS_NAME);
            
            _settingsName = settingsName;
            LoadGameSettings();
        }
        
        public IObservable<GameSettings> LoadGameSettings()
        {
            GameSettings = Resources.Load<GameSettings>(_settingsName);
            return Observable.Return(GameSettings);
        }

        public void Dispose()
        {
            
        }
    }
}