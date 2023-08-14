using Move;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst;
using Unity.Entities;
using UnityEngine;

[BurstCompile]
public partial struct MoveSystem : ISystem
{
    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        foreach(var (moveAspect, linkAspect) in SystemAPI.Query<MoveAspect, InputLink2DataAspect>().WithAll<MoveEnableTag>())
        {
            moveAspect.Move(SystemAPI.Time.DeltaTime);
            linkAspect.Link();
        }
    }
}
