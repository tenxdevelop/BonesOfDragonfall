/**************************************************************************\
   Copyright SunWorldStudio Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Command;

namespace BonesOfDragonfall
{
    public class CmdCheckInteraction : ICommand
    {
        public readonly float DistansInteraction;
        public readonly float PlayerHeight;
        public readonly int PlayerId;

        public IInteractableBinder InteractableBinder { get; private set; }

        public CmdCheckInteraction(float distansInteraction, float playerHeight, int playerId)
        {
            DistansInteraction = distansInteraction;
            PlayerHeight = playerHeight;
            InteractableBinder = null;

            PlayerId = playerId;    
        }

        public void SetInteractableBinder(IInteractableBinder interactableBinder)
        {
            InteractableBinder = interactableBinder;
        }
    }
}
