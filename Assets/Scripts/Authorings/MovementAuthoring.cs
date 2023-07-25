using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Move;

public class MovementAuthoring : MonoBehaviour
{
   public class Baker : Baker<MovementAuthoring>
    {
        public override void Bake(MovementAuthoring authoring)
        {
            var entity = GetEntity(TransformUsageFlags.Dynamic);
            var data = new MoveData { speed = 5.0f };
            AddComponent(entity, data);
        }
    }
}
