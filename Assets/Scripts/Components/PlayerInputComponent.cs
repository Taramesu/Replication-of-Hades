using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

namespace PlayerInput
{
    public struct PlayerInputEnableTag : IComponentData { }

    public struct PlayerInputtingTag : IComponentData { }
    public struct PlayerMoveInput : IComponentData
    {
        public float3 value;
    }

    public struct PlayerDashInput : IComponentData
    {
        public bool value;
    }

    public struct PlayerAttackInput : IComponentData
    {
        public bool value;
        public float2 position;
    }

    public struct PlayerSpecialInput : IComponentData
    {
        public bool value;
    }

    public struct PlayerCastInput : IComponentData
    {
        public bool value;
    }

    public struct PlayerCallInput : IComponentData
    {
        public bool value;
    }
    public struct PlayerInteractInput : IComponentData
    {
        public bool value;
    }

    public struct PlayerGiftInput : IComponentData
    {
        public bool value;
    }

    public struct PlayerBooninfoInput : IComponentData
    {
        public bool value;
    }

    public struct PlayerOpenCodexInput : IComponentData
    {
        public bool value;
    }

    public struct PlayerSummonInput : IComponentData
    {
        public bool value;
    }

    public struct PlayerReloadInput : IComponentData
    {
        public bool value;
    }

    public struct PlayerScreenCaptureInput : IComponentData
    {
        public bool value;
    }
}
