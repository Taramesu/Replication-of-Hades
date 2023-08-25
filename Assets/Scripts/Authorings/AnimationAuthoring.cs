using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Animation;
using PlayerComponents;
using Unity.Collections;

public class AnimationAuthoring : MonoBehaviour
{
    public GameObject prefab;

    public class Baker:Baker<AnimationAuthoring>
    {
        public override void Bake(AnimationAuthoring authoring)
        {
            //var ecb = new EntityCommandBuffer(Allocator.Temp);
            var entity = GetEntity(TransformUsageFlags.Dynamic);
            PresentationGO pgo = new PresentationGO();
            pgo.prefab = authoring.prefab;

            var stateChangeData = new FsmStateChanged
            {
                from = PlayerFsmState.Idle,
                to = PlayerFsmState.Idle,
            };
            var playerFsmData = new PlayerFiniteStateMachine
            {
                currentState = PlayerFsmState.Idle,
            };
            AddComponentObject<PresentationGO>(entity, pgo);
            AddComponent<FsmStateChanged>(entity,stateChangeData);
            AddComponent<PlayerFiniteStateMachine>(entity, playerFsmData);

            var idleData = new IdleState { };
            var runData = new RunState { };
            var attackData = new AttackState { };
            AddComponent<IdleState>(entity, idleData);
           // ecb.SetComponentEnabled<IdleState>(entity,true);
            AddComponent<RunState>(entity, runData);
           // ecb.SetComponentEnabled<RunState>(entity, false);
            AddComponent<AttackState>(entity, attackData);
            //ecb.SetComponentEnabled<AttackState>(entity, false);

            var initializeTag = new InitializeTag();
            AddComponent<InitializeTag>(entity, initializeTag);
            var attackEnableTag = new AttackEnableTag();
            AddComponent<AttackEnableTag>(entity, attackEnableTag);

            var aniStateInfo = new AniStateInfo { value = 0 };
            AddComponent<AniStateInfo> (entity, aniStateInfo);

           // ecb.Dispose();
        }
    }
}
