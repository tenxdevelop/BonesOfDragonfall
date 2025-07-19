/**************************************************************************\
   Copyright SunWorldStudio Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge;

namespace BonesOfDragonfall
{
    public static class GameplayViewModelRegister
    {
        public static void RegisterViewModels(DIContainer container, GameplayEnterParams gameplayEnterParams)
        {
            container.RegisterSingleton<IPlayerViewModel>(factory => new PlayerViewModel(container.Resolve<IGameStateProvider>().GetPlayerModel(), 
                container.Resolve<IPlayerService>(), container.Resolve<IPlayerInput>()));
        }
    }
}