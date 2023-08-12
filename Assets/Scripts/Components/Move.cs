using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace Move
{
    public struct MoveData : IComponentData
    {
        public float3 dir;
        public float speed;
    }

    public struct MoveEnableTag : IComponentData { }

    public struct MovingTag : IComponentData { }
}
