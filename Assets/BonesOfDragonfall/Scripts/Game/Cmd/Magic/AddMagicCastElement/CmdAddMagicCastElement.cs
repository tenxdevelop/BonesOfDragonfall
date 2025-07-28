/**************************************************************************\
   Copyright SunWorldStudio Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Command;

namespace BonesOfDragonfall
{
    public class CmdAddMagicCastElement : ICommand
    {
        public readonly int EntityId;
        
        public readonly MagicElementType AddMagicCastElement;
        public readonly float MagicElementPower;
        public readonly float ElementCostOfMagic;
        
        public CmdAddMagicCastElement(int entityId, MagicElementType addMagicCastElement, float elementCostOfMagic, float power)
        {
            EntityId = entityId;
            AddMagicCastElement = addMagicCastElement;
            ElementCostOfMagic = elementCostOfMagic;
            MagicElementPower = power;
        }

    }
}