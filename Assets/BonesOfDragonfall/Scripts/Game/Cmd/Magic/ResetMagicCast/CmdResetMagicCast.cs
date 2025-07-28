/**************************************************************************\
   Copyright SunWorldStudio Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Command;

namespace BonesOfDragonfall
{
    public class CmdResetMagicCast : ICommand
    {
        public readonly int EntityId;
        
        public CmdResetMagicCast(int entityId)
        {
            EntityId = entityId;
        }
    }
}