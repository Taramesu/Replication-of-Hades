using Move;
using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

readonly partial struct PlayerStatusAspect : IAspect
{
    readonly RefRW<LocalTransform> transform;
    readonly RefRO<MoveData> moveData;

    public void Move(float deltaTime)
    {
        transform.ValueRW.Position.x += moveData.ValueRO.dir.x * moveData.ValueRO.speed * deltaTime;
        transform.ValueRW.Position.z += moveData.ValueRO.dir.z * moveData.ValueRO.speed * deltaTime;
    }
}

