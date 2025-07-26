/**************************************************************************\
   Copyright SunWorldStudio Corporation. All Rights Reserved.
\**************************************************************************/

using System.Collections.Generic;
using System;

namespace BonesOfDragonfall
{
    [Serializable]
    public class PlayerData : EntityStateData
    {
        public float healthPoint;

        public List<MagicElementData> magicCast;
    }
}