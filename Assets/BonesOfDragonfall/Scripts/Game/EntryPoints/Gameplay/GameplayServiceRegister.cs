/**************************************************************************\
   Copyright SunWorldStudio Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Services.ConsoleService;
using SkyForge.Reactive;
using SkyForge.Command;
using SkyForge;

namespace BonesOfDragonfall
{
    public static class GameplayServiceRegister
    {
        public static void RegisterServices(DIContainer container, GameplayEnterParams gameplayEnterParams, SingleReactiveProperty<GameplayExitParams> gameplayExitParams)
        {
            ///////// Init commands /////////////
            
            var commandProcessor = new CommandProcessor();
            var gameStateModel = container.Resolve<IGameStateProvider>().StateModel;
            
            commandProcessor.RegisterCommandHandler(new PlayerMoveCommandHandler(gameStateModel));
            commandProcessor.RegisterCommandHandler(new PlayerRotationCommandHandler(gameStateModel));
            commandProcessor.RegisterCommandHandler(new PlayerJumpCommandHandler(gameStateModel));
            commandProcessor.RegisterCommandHandler(new PlayerChangeMaxSpeedCommandHandler(gameStateModel));
            commandProcessor.RegisterCommandHandler(new PlayerCrouchCommandHandler(gameStateModel));
            commandProcessor.RegisterCommandHandler(new PlayerStandupCommandHandler(gameStateModel));
            commandProcessor.RegisterCommandHandler(new CheckStandupPlayerCommandHandler(gameStateModel));
            commandProcessor.RegisterCommandHandler(new AddItemsToInventoryCommandHandler(gameStateModel, container.Resolve<IItemFactoryService>(), 
                container.Resolve<ISettingsProvider>()));
            commandProcessor.RegisterCommandHandler(new RemoveItemsFromInventoryCommandHandler(gameStateModel));
            commandProcessor.RegisterCommandHandler(new HasItemsInInventoryCommandHandler(gameStateModel));
            commandProcessor.RegisterCommandHandler(new CheckInteractionCommandHandler(gameStateModel));

            
            container.RegisterInstance<ICommandProcessor>(commandProcessor);
            
            /////////////////////////////////////
            
            ///// Init game input system ////////
            
            var gameInputManager = new GameInputManager();
            gameInputManager.RegisterInput<IPlayerInputMapper, PlayerKeyboardAndMouseInputMapper>();
            gameInputManager.RegisterInput<IPlayerInventoryInputMapper, PlayerInventoryKeyboardMapper>();
            
            gameInputManager.Init();
            
            container.RegisterInstance<IPlayerInput>(gameInputManager);
            container.RegisterInstance<IPlayerInventoryInput>(gameInputManager);
            container.RegisterInstance<IInputManager>(gameInputManager);
            
            var consoleServiceInputManager = new ConsoleServiceInputManager();
            
            consoleServiceInputManager.RegisterInput<IConsoleInput, ConsoleServiceInput>();
            container.RegisterInstance(consoleServiceInputManager);
            
            //////////////////////////////////////
            
            container.RegisterSingleton<IPlayerService>(factory => new PlayerService(commandProcessor));
            container.RegisterSingleton<IInventoryService>(factory => new InventoryService(commandProcessor));
            container.RegisterSingleton<IConsoleService>(factory => new ConsoleService(factory));
        }
    }
}