using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Animation;
using PlayerComponents;

public class AnimationAuthoring : MonoBehaviour
{
    public GameObject prefab;

    public class Baker:Baker<AnimationAuthoring>
    {
        public override void Bake(AnimationAuthoring authoring)
        {
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
            AddComponentObject(pgo);
            AddComponent(stateChangeData);    
            AddComponent(playerFsmData);
        }
    }
}
