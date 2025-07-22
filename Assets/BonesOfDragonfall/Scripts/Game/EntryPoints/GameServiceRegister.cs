/**************************************************************************\
   Copyright SunWorldStudio Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge;

namespace BonesOfDragonfall
{
    public static class GameServiceRegister
    {
        public static void RegisterServices(DIContainer container)
        {
            container.RegisterSingleton(factory => new SceneService());
            container.RegisterSingleton(factory => new LoadService());
            container.RegisterSingleton(factory => new ApplicationService());
            
            container.RegisterSingleton<IGameConfigProvider>(factory => new ScriptableObjectGameConfigProvider(ScriptableObjectGameConfigProvider.GAME_CONFIG_NAME));
            
            container.RegisterSingleton<IEntityFactoryService>(factory => new EntityFactoryService());
            container.RegisterSingleton<IItemFactoryService>(factory => new ItemFactoryService(factory.Resolve<IGameConfigProvider>()));
            
            container.RegisterSingleton<IGameStateProvider>(factory => new PlayerPrefsGameStateProvider(factory.Resolve<IEntityFactoryService>(), 
                factory.Resolve<IItemFactoryService>()));
        }
    }
}