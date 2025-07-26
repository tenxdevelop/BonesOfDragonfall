/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using UnityEngine;
using System;

namespace BonesOfDragonfall
{
    public interface IPlayerInput : IDisposable
    {
        public event Action<Vector2> PlayerMovedReceivedEvent;
        public event Action<Vector2> PlayerCameraRotationReceivedEvent;
        public bool PlayerJumpPressed();
        public bool PlayerSprintingPressed();
        public bool PlayerCrouchPressed();
        public bool DisablePlayerInput();
        public void EnablePlayerInput();
        public bool DisablePlayerMovementInput();
        public void EnablePlayerMovementInput();
        public bool PlayerInteractionPressed();
        public bool PlayerOpenInventoryPressed();
        public bool PlayerStartMagicCastPressed();
    }
}