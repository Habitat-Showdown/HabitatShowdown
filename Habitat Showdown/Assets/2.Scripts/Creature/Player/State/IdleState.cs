using UnityEngine;

namespace CharacterController
{
    public class IdleState : BaseState
    {
        public IdleState(PlayerController controller) : base(controller)
        {
            
        }
        public override void OnEnterState()
        {
            
        }

        public override void OnUpdateState()
        {
            
        }

        public override void OnFixedUpdateState()
        {
            if (Controller.inputVec.magnitude > 0) { Controller.player.stateMachine.ChangeState(StateName.Move);  Debug.Log("ChangeState: Move"); }
        }

        public override void OnLateUpdateState()
        {
            
        }

        public override void OnExitState()
        {
            
        }
    }
}