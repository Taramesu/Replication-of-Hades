using PlayerInput;
using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

readonly partial struct PlayerInputAspect : IAspect
{
    readonly RefRW<PlayerMoveInput> moveInput;
    readonly RefRW<PlayerDashInput> dashInput;
    readonly RefRW<PlayerAttackInput> attackInput;
    readonly RefRW<PlayerSpecialInput> specialInput;
    readonly RefRW<PlayerCastInput> castInput;
    readonly RefRW<PlayerCallInput> callInput;
    readonly RefRW<PlayerInteractInput> interactInput;
    readonly RefRW<PlayerGiftInput> giftInput;
    readonly RefRW<PlayerBooninfoInput> booninfoInput;
    readonly RefRW<PlayerOpenCodexInput> openCodexInput;
    readonly RefRW<PlayerSummonInput> summonInput;
    readonly RefRW<PlayerReloadInput> reloadInput;
    readonly RefRW<PlayerScreenCaptureInput> screenCaptureInput;

    public void ResetInputData()
    {
        dashInput.ValueRW.value = false;
        attackInput.ValueRW.value = false;
        specialInput.ValueRW.value = false;
        castInput.ValueRW.value = false;
        callInput.ValueRW.value = false;
        interactInput.ValueRW.value = false;
        giftInput.ValueRW.value = false;
        booninfoInput.ValueRW.value = false;
        openCodexInput.ValueRW.value = false;
        summonInput.ValueRW.value = false;
        reloadInput.ValueRW.value = false;
        screenCaptureInput.ValueRW.value = false;
    }

    public void print()
    {
        Debug.Log(specialInput.ValueRO.value);
    }
}
