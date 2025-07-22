/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Input;
using UnityEngine;
using System;

namespace BonesOfDragonfall
{
    public interface IPlayerInputMapper : IInput
    {
        public event Action<Vector2> PlayerMovedReceivedEvent;
        public event Action<Vector2> PlayerCameraRotationReceivedEvent;
        
        public bool PlayerJumpPressed();
        
        public bool PlayerSprintingPressed();

        public bool PlayerCrouchPressed();

        public bool PlayerInteractionPressed();
    }
}