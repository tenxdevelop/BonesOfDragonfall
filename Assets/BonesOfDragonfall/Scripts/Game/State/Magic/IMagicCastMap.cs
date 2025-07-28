/**************************************************************************\
   Copyright SunWorldStudio Corporation. All Rights Reserved.
\**************************************************************************/

using System.Collections.Generic;

namespace BonesOfDragonfall
{
    public interface IMagicCastMap
    {
        void InitMagicCastMap();

        void GetMagic(List<MagicElementType> magicCast);
    }
}