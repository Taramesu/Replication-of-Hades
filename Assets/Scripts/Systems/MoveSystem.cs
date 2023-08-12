using Move;
using PlayerComponents;
using PlayerInput;
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
        foreach(var moveAspect in SystemAPI.Query<MoveAspect>().WithAll<MoveEnableTag>())
        {
            moveAspect.Move(SystemAPI.Time.DeltaTime);
            moveAspect.SynchronousRotation();
        }
    }
}
