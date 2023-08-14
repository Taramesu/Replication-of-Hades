using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TraitComponents;
using Unity.Burst;
using Unity.Jobs;
using Unity.Entities;
using Unity.VisualScripting;
using UnityEngine;
using Unity.Collections;

[UpdateInGroup(typeof(SimulationSystemGroup), OrderLast = true)]
[UpdateAfter(typeof(InitializationSystemGroup))]
public partial class RandomTraitSystem : SystemBase
{
    protected override void OnCreate()
    {
        
    }

    protected override void OnUpdate()
    {
        //ecb = ecbSystem.CreateCommandBuffer();
        //var entityCommandBuffer = new EntityCommandBuffer().AsParallelWriter();
        NativeList<Entity> traitEntities = new NativeList<Entity>(Allocator.TempJob);
        Entities
            .WithAll<TraitTypeTag, IsRandomTrait>() 
            .ForEach
            ((Entity entity,in TraitTypeTag traitTypeTag, in IsRandomTrait isRandomTrait) =>
        {
            //RandomTrait(traitTypeTag);
            //entityCommandBuffer.DestroyEntity(entityInQueryIndex,entity);

            if (isRandomTrait.value)
            {
                

                //traitEntities.Add(entity);
            }
        }).Schedule();
        //jobHandle.Complete();

        /*for (int i = 0; i < traitEntities.Length; i++)
        {
            EntityManager.DestroyEntity(traitEntities[i]);
        }*/
        EntityQuery entitys = this.GetEntityQuery(typeof(IsRandomTrait));
        EntityManager.DestroyEntity(entitys);
    }
}
