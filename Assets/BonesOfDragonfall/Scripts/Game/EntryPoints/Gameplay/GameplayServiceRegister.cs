/**************************************************************************\
   Copyright SunWorldStudio Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Reactive;
using SkyForge;

namespace BonesOfDragonfall
{
    public static class GameplayServiceRegister
    {
        public static void RegisterServices(DIContainer container, GameplayEnterParams gameplayEnterParams, SingleReactiveProperty<GameplayExitParams> gameplayExitParams)
        {
            //Init game input system
            var gameInputManager = new GameInputManager();
            gameInputManager.RegisterInput<IPlayerInputMapper, PlayerKeyboardAndMouseInputMapper>();
            
            gameInputManager.Init();
            
            container.RegisterInstance<IPlayerInput>(gameInputManager);
        }
    }
}