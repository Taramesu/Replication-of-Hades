using System.Collections;
using System.Collections.Generic;
using TraitComponents;
using Unity.Entities;
using UnityEngine;

public class TraitEntityAuthoring : MonoBehaviour
{
    public TraitType traitType;
    // Start is called before the first frame update
    public class Baker : Baker<TraitEntityAuthoring>
    {
        public override void Bake(TraitEntityAuthoring authoring)
        {
            var entity = GetEntity(TransformUsageFlags.Dynamic);
            var traitType = new TraitTypeTag { value = authoring.traitType };
            var isRandom = new RandomTrait();

            AddComponent(entity, traitType);
            AddComponent(entity, isRandom);
        }
    }
}
