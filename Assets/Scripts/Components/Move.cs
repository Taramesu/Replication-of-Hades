using Unity.Entities;
using Unity.Mathematics;
namespace Move
{
    public struct MoveData : IComponentData
    {
        public float3 dir;
        public float speed;
    }

    public struct MoveEnableTag : IComponentData,IEnableableComponent { }

    public struct MovingTag : IComponentData,IEnableableComponent { }
}
