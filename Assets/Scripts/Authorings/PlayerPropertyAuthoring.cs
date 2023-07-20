using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class PlayerPropertyAuthoring : MonoBehaviour
{
   public class Baker : Baker<PlayerPropertyAuthoring>
   {
        public override void Bake(PlayerPropertyAuthoring authoring)
        {
            var entity = GetEntity(TransformUsageFlags.Dynamic);
            var PlayerTag = new player.PlayerTag { };
            AddComponent(entity, PlayerTag);
        }
   }
}
