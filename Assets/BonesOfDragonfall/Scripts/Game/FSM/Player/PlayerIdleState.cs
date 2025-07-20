using SkyForge.FSM;
using UnityEngine;

namespace BonesOfDragonfall
{
    public class PlayerIdleState : IState
    {
        public void OnStart()
        {
            Debug.Log("playerIdle");
        }

        public void OnUpdate(float deltaTime)
        {
            
        }

        public void OnPhysicsUpdate(float deltaTime)
        {
            
        }

        public void OnExit()
        {
            
        }
    }
}