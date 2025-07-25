/**************************************************************************\
   Copyright SunWorldStudio Corporation. All Rights Reserved.
\**************************************************************************/

using System;

namespace BonesOfDragonfall
{
    public interface IPlayerInventoryInput  : IDisposable
    {
        public bool PlayerOpenInventoryPressed();
    }
}