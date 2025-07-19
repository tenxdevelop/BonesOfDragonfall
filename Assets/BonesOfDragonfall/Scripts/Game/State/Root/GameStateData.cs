/**************************************************************************\
   Copyright SunWorldStudio Corporation. All Rights Reserved.
\**************************************************************************/

using System.Collections.Generic;
using System;

namespace BonesOfDragonfall
{
    [Serializable]
    public class GameStateData
    {
        public int globalEntityId;
        
        public List<EntityStateData> entities;
    }
}