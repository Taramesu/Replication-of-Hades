using UnityEngine;
using Unity.Entities;
using Move;

public class MovementAuthoring : MonoBehaviour
{
    public float speed;
   public class Baker : Baker<MovementAuthoring>
    {
        public override void Bake(MovementAuthoring authoring)
        {
            var entity = GetEntity(TransformUsageFlags.Dynamic);
            var data = new MoveData { speed = authoring.speed };
            AddComponent(entity, data);
        }
    }
}
