/**************************************************************************\
   Copyright SunWorldStudio Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Services.ConsoleService;
using SkyForge.Extension;
using System.Linq;
using SkyForge;

namespace BonesOfDragonfall
{
    public static class GameplayViewModelRegister
    {
        public static void RegisterViewModels(DIContainer container, GameplayEnterParams gameplayEnterParams)
        {
            var playerInventory = container.Resolve<IGameStateProvider>().StateModel.InventoryMaps.FirstOrDefault(currentInventory => currentInventory.OwnerId.Equals(InventoryService.PLAYER_INVENTORY_ID));
            var itemMapConfig = container.Resolve<ISettingsProvider>().GameSettings.itemsMap;
            container.RegisterSingleton<IUIPlayerInventoryViewModel>(factory => new UIPlayerInventoryViewModel(playerInventory, itemMapConfig,
                factory.Resolve<IPlayerInventoryInput>(), factory.Resolve<IPlayerInput>(),  factory.Resolve<IPlayerMagicInput>(), 
                factory.Resolve<ApplicationService>()));
            
            container.RegisterSingleton<IConsoleServiceViewModel>(factory => new ConsoleServiceViewModel(factory.Resolve<IConsoleService>(), 
                factory.Resolve<ConsoleServiceInputManager>().GetConsoleInput()));
            container.RegisterSingleton<IUIRootGameplayViewModel>(factory => new UIRootGameplayViewModel(factory.Resolve<IConsoleServiceViewModel>(), 
                factory.Resolve<IInputManager>(), factory.Resolve<ApplicationService>()));
            
            container.RegisterSingleton<IUIRootPlayerHUDViewModel>(factory => new UIRootPlayerHUDViewModel(factory.Resolve<IGameStateProvider>().GetPlayerModel()));
            
            container.RegisterSingleton<IPlayerViewModel>(factory => new PlayerViewModel(factory.Resolve<IGameStateProvider>().GetPlayerModel(), 
                factory.Resolve<ISettingsProvider>(), factory.Resolve<IPlayerService>(), factory.Resolve<IPlayerInput>(), 
                factory.Resolve<IPlayerMagicInput>(),factory.Resolve<Coroutines>(), factory.Resolve<IUIRootPlayerHUDViewModel>()));
        }
    }
}