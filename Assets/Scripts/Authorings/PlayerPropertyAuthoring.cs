using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Move;
using PlayerComponents;

public class PlayerPropertyAuthoring : MonoBehaviour
{
   public class Baker : Baker<PlayerPropertyAuthoring>
   {
        public override void Bake(PlayerPropertyAuthoring authoring)
        {
            var entity = GetEntity(TransformUsageFlags.Dynamic);
            var PlayerTag = new PlayerTag { };
            var MoveEnableTag = new MoveEnableTag { };
            AddComponent(entity, PlayerTag);
            AddComponent(entity, MoveEnableTag);
        }
   }
}
