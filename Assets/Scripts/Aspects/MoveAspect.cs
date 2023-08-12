using Move;
using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

readonly partial struct MoveAspect : IAspect
{
    readonly RefRW<LocalTransform> transform;
    readonly RefRO<MoveData> moveData; 

    public void Move(float deltaTime)
    {
        transform.ValueRW.Position.x += moveData.ValueRO.dir.x * moveData.ValueRO.speed * deltaTime;
        transform.ValueRW.Position.z += moveData.ValueRO.dir.z * moveData.ValueRO.speed * deltaTime;
    }

    public bool GetMoving()
    {
        if (math.lengthsq(moveData.ValueRO.dir) > float.Epsilon)
        {
            return true;
        }
        else return false;
    }

    public void SynchronousRotation()
    {
        if(math.lengthsq(moveData.ValueRO.dir)>float.Epsilon)
        {
            var forward = new float3(moveData.ValueRO.dir);
            transform.ValueRW.Rotation = Quaternion.LookRotation(forward, math.up());
        }
    }
}
