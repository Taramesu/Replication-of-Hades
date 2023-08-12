using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;


namespace PlayerComponents
{
    enum PlayerFsmState
    {
        Idle,
        Run,
        Attack
    }

    struct IdleState : IComponentData
    {

    }
    struct RunState : IComponentData
    {
        
    }
    struct AttackState : IComponentData
    {
        public float stateInfo;
        public float2 targetMousePosition;
        public float3 targetWorldPosition;
    }

    struct FsmStateChanged : IComponentData 
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

    struct PlayerTag : IComponentData { }
}
