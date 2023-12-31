using PlayerComponents;
using PlayerInput;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst;
using Unity.Entities;
using UnityEngine;
using UnityEngine.InputSystem;

[BurstCompile]
public partial struct IdleStateSystem : ISystem
{
    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        var ecbBOS = SystemAPI.GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>().CreateCommandBuffer(state.WorldUnmanaged);

        foreach (var (moveAspect, entity) in SystemAPI.Query<MoveAspect>().WithEntityAccess().WithAll<IdleState>())
        {
            if (moveAspect.GetMoving())
            {
                ecbBOS.SetComponentEnabled<FsmStateChanged>(entity, true);
                //ecbBOS.AddComponent<FsmStateChanged>(entity);
                ecbBOS.SetComponent(entity, new FsmStateChanged
                {
                    from = PlayerFsmState.Idle,
                    to = PlayerFsmState.Run
                });
            }
        }

        foreach (var (input, entity) in SystemAPI.Query<PlayerAttackInput>().WithEntityAccess().WithAll<IdleState>())
        {
            if (input.value)
            {
                ecbBOS.SetComponentEnabled<FsmStateChanged>(entity, true);
                //ecbBOS.AddComponent<FsmStateChanged>(entity);
                ecbBOS.SetComponent(entity, new FsmStateChanged
                {
                    from = PlayerFsmState.Idle,
                    to = PlayerFsmState.Attack
                });
                //Debug.Log(input.value);
                //Debug.Log();
            }
        }
    }
}
