using Animation;
using Move;
using PlayerComponents;
using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Transforms;
using UnityEditor.Rendering;
using UnityEngine;

public partial struct AnimationSystem : ISystem
{
    public void OnUpdate(ref SystemState state)
    {
        var ecbBOS = SystemAPI.GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>().CreateCommandBuffer(state.WorldUnmanaged);
        //组件获取(反应式系统)
        foreach (var (pgo, entity) in SystemAPI.Query<PresentationGO>().WithEntityAccess())
        {
            GameObject go = GameObject.Instantiate(pgo.prefab);
            ecbBOS.AddComponent(entity, new TransformGO() { transform = go.transform });
            ecbBOS.AddComponent(entity, new AnimatorGO() { animator = go.GetComponent<Animator>() });
            ecbBOS.RemoveComponent<PresentationGO>(entity);
        }

        //位置同步
        foreach (var (goTransform, transform) in SystemAPI.Query<TransformGO, LocalTransform>())
        {
            goTransform.transform.position = transform.Position;
            goTransform.transform.rotation = transform.Rotation;
        }

        //动画控制同步状态机
        foreach (var (animatorGO, playerFsm,stateChanged,entity) in SystemAPI.Query<AnimatorGO, RefRW<PlayerFiniteStateMachine>,FsmStateChanged>().WithEntityAccess())
        {
            switch(stateChanged.from)
            {
                case PlayerFsmState.Idle:
                    ecbBOS.RemoveComponent<IdleState>(entity);
                    break;
                case PlayerFsmState.Run:
                    ecbBOS.RemoveComponent<RunState>(entity);
                    break;
                case PlayerFsmState.Attack:
                    ecbBOS.RemoveComponent<AttackState>(entity);
                    ecbBOS.AddComponent<MoveEnableTag>(entity);
                    break;
            }

            playerFsm.ValueRW.currentState = stateChanged.to;

            switch (stateChanged.to)
            {
                case PlayerFsmState.Idle:
                    ecbBOS.AddComponent<IdleState>(entity);
                    animatorGO.animator.Play("Idle");
                    break;
                case PlayerFsmState.Run:
                    ecbBOS.AddComponent<RunState>(entity);
                    animatorGO.animator.Play("Run");
                    break;
                case PlayerFsmState.Attack:
                    ecbBOS.AddComponent<AttackState>(entity);
                    ecbBOS.RemoveComponent<MoveEnableTag>(entity);
                    animatorGO.animator.Play("Attack");
                    break;
            }
            ecbBOS.RemoveComponent<FsmStateChanged>(entity);
        }

        //动画播放进度同步
        foreach (var (animatorGO,attackInfo) in SystemAPI.Query<AnimatorGO,RefRW<AttackState>>())
        {
            var stateInfo = animatorGO.animator.GetCurrentAnimatorStateInfo(0);
            if(stateInfo.IsName("Attack"))
            {
                attackInfo.ValueRW.stateInfo = stateInfo.normalizedTime;
            }
        }
        Camera camera = Camera.main;
        //摄像头鼠标点击坐标转换同步
        foreach (var attackState in SystemAPI.Query<RefRW<AttackState>>())
        {
            var position = attackState.ValueRO.targetMousePosition;
            attackState.ValueRW.targetWorldPosition = camera.ScreenToWorldPoint(new Vector3(position.x,position.y,camera.nearClipPlane));
            attackState.ValueRW.targetWorldPosition.y = 0;
            Debug.Log(attackState.ValueRO.targetWorldPosition);
        }
    }
}
