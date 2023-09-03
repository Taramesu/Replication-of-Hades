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
        Camera camera = Camera.main;
        var ecbBOS = SystemAPI.GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>().CreateCommandBuffer(state.WorldUnmanaged);
        //组件获取(反应式系统)
        foreach (var (pgo, entity) in SystemAPI.Query<PresentationGO>().WithEntityAccess())
        {
            GameObject go = GameObject.Instantiate(pgo.prefab);
            ecbBOS.AddComponent(entity, new TransformGO() { transform = go.transform });
            ecbBOS.AddComponent(entity, new AnimatorGO() { animator = go.GetComponent<Animator>() });
            ecbBOS.RemoveComponent<PresentationGO>(entity);
        }

        //组件数据初始化
        foreach (var (iniTag, entity) in SystemAPI.Query<InitializeTag>().WithEntityAccess())
        {
            ecbBOS.SetComponentEnabled<RunState>(entity,false);
            ecbBOS.SetComponentEnabled<AttackState>(entity,false);
            ecbBOS.RemoveComponent<InitializeTag>(entity);
        }

        //位置同步
        foreach (var (goTransform, transform) in SystemAPI.Query<TransformGO, LocalTransform>())
        {
            goTransform.transform.position = transform.Position;
            goTransform.transform.rotation = transform.Rotation;
        }

        //相机跟随
        foreach(var transform in SystemAPI.Query<LocalTransform>())
        {
            camera.transform.localPosition = new Vector3(transform.Position.x, camera.transform.localPosition.y, transform.Position.z);
        }

        //动画控制同步状态机
        foreach (var (animatorGO, playerFsm,stateChanged,entity) in SystemAPI.Query<AnimatorGO, RefRW<PlayerFiniteStateMachine>,FsmStateChanged>().WithEntityAccess())
        {
            switch(stateChanged.from)
            {
                case PlayerFsmState.Idle:
                    ecbBOS. SetComponentEnabled<IdleState>(entity,false);
                    break;
                case PlayerFsmState.Run:
                    ecbBOS.SetComponentEnabled<RunState>(entity, false);
                    break;
                case PlayerFsmState.Attack:
                    ecbBOS.SetComponentEnabled<AttackState>(entity, false);
                    ecbBOS.SetComponentEnabled<MoveEnableTag>(entity, true);
                    ecbBOS.SetComponentEnabled<AttackEnableTag>(entity, true);
                    break;
            }

            playerFsm.ValueRW.currentState = stateChanged.to;

            switch (stateChanged.to)
            {
                case PlayerFsmState.Idle:
                    ecbBOS.SetComponentEnabled<IdleState>(entity, true);
                    animatorGO.animator.Play("Idle");
                    break;
                case PlayerFsmState.Run:
                    ecbBOS.SetComponentEnabled<RunState>(entity, true);
                    animatorGO.animator.Play("Run");
                    break;
                case PlayerFsmState.Attack:
                    ecbBOS.SetComponentEnabled<AttackState>(entity, true);
                    ecbBOS.SetComponentEnabled<MoveEnableTag>(entity, false);
                    animatorGO.animator.Play("Attack");
                    break;
            }
            ecbBOS.SetComponentEnabled<FsmStateChanged>(entity, false);
        }

        //动画播放进度同步
        foreach (var (animatorGO,stateInfo) in SystemAPI.Query<AnimatorGO,RefRW<AniStateInfo>>())
        {
            animatorGO.animator.GetCurrentAnimatorStateInfo(0);
            stateInfo.ValueRW.value = animatorGO.animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
        }
        
        //摄像头鼠标点击坐标转换同步
        foreach (var attackState in SystemAPI.Query<RefRW<AttackState>>())
        {
            var position = attackState.ValueRO.targetMousePosition;
            attackState.ValueRW.targetWorldPosition = camera.ScreenToWorldPoint(new Vector3(position.x,position.y,camera.nearClipPlane));
            attackState.ValueRW.targetWorldPosition.y = 0;
        }
    }
}
