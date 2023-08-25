using Unity.Entities;
using Unity.Mathematics;


namespace PlayerComponents
{
    enum PlayerFsmState
    {
        Idle,
        Run,
        Attack
    }

    struct IdleState : IComponentData,IEnableableComponent
    {

    }
    struct RunState : IComponentData, IEnableableComponent
    {
        
    }
    struct AttackState : IComponentData, IEnableableComponent
    {
        public float2 targetMousePosition;
        public float3 targetWorldPosition;
        public bool isAttacking;
    }

    struct AniStateInfo : IComponentData
    {
        public float value;
    }

    struct FsmStateChanged : IComponentData,IEnableableComponent
    {
        public PlayerFsmState from;
        public PlayerFsmState to;
    }

    struct PlayerFiniteStateMachine : IComponentData 
    {
        public PlayerFsmState currentState;
    }

    struct Player : IComponentData
    {
        public float HP;//0:to death 100:health
    }

    struct PlayerTag : IComponentData, IEnableableComponent{ }

    struct InitializeTag : IComponentData { }

    struct AttackEnableTag : IComponentData, IEnableableComponent { }

}
