/**************************************************************************\
   Copyright SunWorldStudio Corporation. All Rights Reserved.
\**************************************************************************/

using System;

namespace BonesOfDragonfall
{
    public interface IInputManager : IDisposable
    {
        void DisableInput();
        void EnableInput();
    }
}