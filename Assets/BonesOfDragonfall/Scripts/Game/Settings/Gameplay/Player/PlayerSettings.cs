/**************************************************************************\
   Copyright SunWorldStudio Corporation. All Rights Reserved.
\**************************************************************************/

using UnityEngine;

namespace BonesOfDragonfall
{
    [CreateAssetMenu(fileName = "New player settings", menuName = "Game settings/Player/New player settings")]
    public class PlayerSettings : ScriptableObject
    {
        public float sensitivityX;
        public float sensitivityY;

        public float playerHeight;

        public float playerSpeed;
        public float maxPlayerSpeed;
        public float playerAirSpeed;
        public float playerMultiplayerSprintingSpeed;

        public float dragMovement;

        public float jumpForce;

        public float playerCrouchScale;
        public float playerMaxSpeedCrouch;
    }
}