/**************************************************************************\
   Copyright SunWorldStudio Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Command;
using UnityEngine;

namespace BonesOfDragonfall
{
    public class CmdPlayerMove : ICommand
    {
        public readonly Vector2 Direction;
        public readonly float Speed;
        public readonly float AirSpeed;
        public readonly bool PlayerInGround;
        public readonly float DragMovement;
        public readonly int PlayerId;

        public CmdPlayerMove(Vector2 direction, float speed, float airSpeed, float dragMovement, bool playerInGround, int playerId)
        {
            Direction = direction;
            Speed = speed;
            AirSpeed = airSpeed;
            DragMovement = dragMovement;
            PlayerInGround = playerInGround;
            PlayerId = playerId;
        }
    }
}