using UnityEngine;

namespace CharacterController
{
    public class MoveState : BaseState
    {
        public MoveState(PlayerController controller) : base(controller)
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
            if(Controller.inputVec.magnitude <= 0) { Controller.player.stateMachine.ChangeState(StateName.Idle); Debug.Log("ChangeState: Idle"); }
            Vector2 nextVec = Controller.inputVec * (Controller.player.MoveSpeed * Time.fixedDeltaTime);
            Controller.player.rigidBody.MovePosition(Controller.player.rigidBody.position + nextVec);
        }

        public override void OnLateUpdateState()
        {
            Controller.player.animator.SetFloat("Speed", Controller.inputVec.magnitude);
            
            if (Controller.inputVec.x != 0)
            {
                Controller.player.spriter.flipX = Controller.inputVec.x < 0;
            }
        }

        public override void OnExitState()
        {
            
        }
    }
}