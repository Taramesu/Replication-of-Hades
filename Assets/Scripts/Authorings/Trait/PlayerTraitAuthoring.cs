using UnityEngine;
using Unity.Entities;
using TraitComponents;
using Unity.Collections;

public class PlayerTraitAuthoring : MonoBehaviour
{
    public class Baker : Baker<PlayerTraitAuthoring>
    {
        public override void Bake(PlayerTraitAuthoring authoring)
        {
            var entity = GetEntity(TransformUsageFlags.Dynamic);
            var pickedTrait = new PickedTraitDic { value = new NativeList<PickedTrait>(Allocator.Persistent) };
            var pickableTrait = new PickableTraitDic { value = new NativeList<PickableTrait>(Allocator.Persistent) { } };
            var pickedSocket = new PickedSocket { value = new NativeList<int>(Allocator.Persistent) { 1 } };
            var randomCount = new RandomCount { value = 0 };

            PickableTraitData temp1 = new PickableTraitData { traitID = 10033 };
            PickableTraitData temp2 = new PickableTraitData { traitID = 10044 };
            PickableTrait t = new PickableTrait { type = (int)TraitType.Zeus, value = new NativeList<PickableTraitData>(Allocator.Persistent) { temp1,temp2 } };
            pickableTrait.value.Add(t);

            AddComponent(entity, pickedTrait);
            AddComponent(entity, pickableTrait);
            AddComponent(entity, pickedSocket);
            AddComponent(entity, randomCount);
        }
    }
}
