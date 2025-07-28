/**************************************************************************\
   Copyright SunWorldStudio Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Services.ConsoleService;
using UnityEngine;
using SkyForge;

namespace BonesOfDragonfall
{
    public class ChangeHealthPlayerConsoleCommand : IConsoleCommand
    {
        public string CommandName => "ChangeHealthPlayer";
        
        public void Process(DIContainer container, string[] parameters)
        {
            var updateValue = int.Parse(parameters[0]);
        
            var playerModel = container.Resolve<IGameStateProvider>().GetPlayerModel();
            
            playerModel.HealthPoint.Value += updateValue;
        }

        
    }
}