using Move;
using PlayerComponents;
using PlayerInput;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

[BurstCompile]
public partial struct LinkInputDataSystem : ISystem
{
    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        foreach(var (moveData,input) in SystemAPI.Query<RefRW<MoveData>, RefRO<PlayerMoveInput>>())
        {
            moveData.ValueRW.dir = input.ValueRO.value;
        }

        foreach (var (attackState,input) in SystemAPI.Query<RefRW<AttackState>,RefRO<PlayerAttackInput>>().WithAll<AttackEnableTag>())
        {
            attackState.ValueRW.targetMousePosition = input.ValueRO.position;
        }
    }
}
