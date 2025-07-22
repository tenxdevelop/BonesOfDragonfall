/**************************************************************************\
   Copyright SunWorldStudio Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Reactive.Extension;
using SkyForge.Reactive;
using UnityEngine;

namespace BonesOfDragonfall
{
    public class ScriptableObjectGameConfigProvider : IGameConfigProvider
    {
        public const string GAME_CONFIG_NAME = "Configs/GameConfig";
        public GameConfig GameConfig { get; private set; }

        private string _configName;
        
        public ScriptableObjectGameConfigProvider(string configName)
        {
            _configName = configName;
            LoadGameConfig();
        }
        
        public IObservable<GameConfig> LoadGameConfig()
        {
            GameConfig = Resources.Load<GameConfig>(_configName);
            return Observable.Return(GameConfig);
        }

        public void Dispose()
        {
            
        }
    }
}