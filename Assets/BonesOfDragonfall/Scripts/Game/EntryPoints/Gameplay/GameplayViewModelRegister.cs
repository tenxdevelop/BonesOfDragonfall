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
            container.RegisterSingleton<IPlayerViewModel>(factory => new PlayerViewModel(container.Resolve<IGameStateProvider>().GetPlayerModel(), 
                container.Resolve<ISettingsProvider>(), container.Resolve<IPlayerService>(), container.Resolve<IPlayerInput>(), 
                container.Resolve<Coroutines>()));
            
            
            var playerInventory = container.Resolve<IGameStateProvider>().StateModel.InventoryMaps.FirstOrDefault(currentInventory => currentInventory.OwnerId.Equals(InventoryService.PLAYER_INVENTORY_ID));
            var itemMapConfig = container.Resolve<ISettingsProvider>().GameSettings.itemsMap;
            container.RegisterSingleton<IUIPlayerInventoryViewModel>(factory => new UIPlayerInventoryViewModel(playerInventory, itemMapConfig,
                factory.Resolve<IPlayerInventoryInput>(), factory.Resolve<IPlayerInput>(), factory.Resolve<ApplicationService>()));
            
            container.RegisterSingleton<IConsoleServiceViewModel>(factory => new ConsoleServiceViewModel(factory.Resolve<IConsoleService>(), 
                factory.Resolve<ConsoleServiceInputManager>().GetConsoleInput()));
            container.RegisterSingleton<IUIRootGameplayViewModel>(factory => new UIRootGameplayViewModel(factory.Resolve<IConsoleServiceViewModel>(), 
                factory.Resolve<IInputManager>(), factory.Resolve<ApplicationService>()));
        }
    }
}