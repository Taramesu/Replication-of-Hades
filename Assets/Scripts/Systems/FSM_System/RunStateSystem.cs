using PlayerComponents;
using Unity.Burst;
using Unity.Entities;

[BurstCompile]
public partial struct RunStateSystem : ISystem
{
    [BurstCompile]
    public  void OnUpdate(ref SystemState state)
    {
        var ecbBOS = SystemAPI.GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>().CreateCommandBuffer(state.WorldUnmanaged);

        foreach(var(aspect,entity) in SystemAPI.Query<MoveAspect>().WithEntityAccess().WithAll<RunState>())
        {
            if(!aspect.GetMoving())
            {
                ecbBOS.AddComponent<FsmStateChanged>(entity);
                ecbBOS.SetComponent(entity, new FsmStateChanged
                {
                    from = PlayerFsmState.Run,
                    to = PlayerFsmState.Idle
                }) ;
            }
        }
    }
}
