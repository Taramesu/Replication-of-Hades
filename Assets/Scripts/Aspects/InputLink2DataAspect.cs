using Move;
using PlayerInput;
using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

readonly partial struct InputLink2DataAspect : IAspect
{
    readonly RefRO<PlayerMoveInput> moveInput;
    readonly RefRO<PlayerDashInput> DashInput;
    readonly RefRO<PlayerAttackInput> attackInput;
    readonly RefRO<PlayerSpecialInput> specialInput;
    readonly RefRO<PlayerCastInput> castInput;
    readonly RefRO<PlayerCallInput> callInput;
    readonly RefRO<PlayerInteractInput> interactInput;
    readonly RefRO<PlayerGiftInput> giftInput;
    readonly RefRO<PlayerBooninfoInput> booninfoInput;
    readonly RefRO<PlayerOpenCodexInput> openCodexInput;
    readonly RefRO<PlayerSummonInput> summonInput;
    readonly RefRO<PlayerReloadInput> reloadInput;
    readonly RefRO<PlayerScreenCaptureInput> screenCaptureInput;

    readonly RefRW<MoveData> moveData;


    public void Link()
    {
        moveData.ValueRW.dir = new float3 { x = moveInput.ValueRO.value.x, y = 0, z = moveInput.ValueRO.value.z };
    }
}
