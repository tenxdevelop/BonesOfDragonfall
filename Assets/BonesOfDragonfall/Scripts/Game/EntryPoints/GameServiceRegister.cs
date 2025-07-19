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
        }
    }
}