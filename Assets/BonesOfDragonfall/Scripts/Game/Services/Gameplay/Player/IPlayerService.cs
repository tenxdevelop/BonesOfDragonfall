/**************************************************************************\
   Copyright SunWorldStudio Corporation. All Rights Reserved.
\**************************************************************************/

using UnityEngine;
using System;

namespace BonesOfDragonfall
{
    public interface IPlayerService : IDisposable
    {
        void Move(Vector2 direction, float speed, int playerId);
        
        void PlayerRotation(Vector2 direction, float sensitivityX, float sensitivityY, int playerId);
        
    }
}