using PlayerComponents;
using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

[BurstCompile]
public partial struct AttackStateSystem : ISystem
{
    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        var ecbBOS = SystemAPI.GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>().CreateCommandBuffer(state.WorldUnmanaged);

        foreach (var ( playerState,transform, entity) in SystemAPI.Query<RefRO<AttackState>,RefRW<LocalTransform>>().WithEntityAccess().WithAll<AttackState>())
        {
            var forward = math.normalize(new float3(playerState.ValueRO.targetWorldPosition) - transform.ValueRO.Position);
            transform.ValueRW.Rotation = Quaternion.LookRotation(forward, math.up());

            //Debug.Log(playerState.ValueRO.targetWorldPosition);

            if (playerState.ValueRO.stateInfo>0.95f)
            {
                ecbBOS.AddComponent<FsmStateChanged>(entity);
                ecbBOS.SetComponent(entity, new FsmStateChanged
                {
                    from = PlayerFsmState.Attack,
                    to = PlayerFsmState.Idle
                });
            }
        }
    }
}
