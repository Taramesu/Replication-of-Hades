using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using PlayerComponents;
using PlayerInput;
using UnityEngine.UI;
using UnityEngine.InputSystem;

[UpdateInGroup(typeof(InitializationSystemGroup), OrderLast = true)]
public partial class GetPlayerInputSystem : SystemBase
{
    private MovementAction movementAction;
    protected override void OnCreate()
    {
        RequireForUpdate<PlayerTag>();
        RequireForUpdate<PlayerMoveInput>();

        movementAction = new MovementAction();
    }

    protected override void OnStartRunning()
    {
        movementAction.Enable();
        movementAction.ControlMap.PlayerDash.started += OnPlayerDash;
        movementAction.ControlMap.PlayerAttack.started += OnPlayerAttack;
        movementAction.ControlMap.PlayerSpecial.started += OnPlayerSpecial;
        movementAction.ControlMap.PlayerCast.started += OnPlayerCast;
        movementAction.ControlMap.PlayerCall.started += OnPlayerCall;
        movementAction.ControlMap.PlayerInteract.started += OnPlayerInteract;
        movementAction.ControlMap.PlayerGift.started += OnPlayerGift;
        movementAction.ControlMap.PlayerBooninfo.started += OnPlayerBooninfo;
        movementAction.ControlMap.PlayerOpenCodex.started += OnPlayerOpenCodex;
        movementAction.ControlMap.PlayerSummon.started += OnPlayerSummon;
        movementAction.ControlMap.PlayerReload.started += OnPlayerReload;
        movementAction.ControlMap.PlayerScreenCapture.started += OnPlayerScreenCapture;
    }

    protected override void OnUpdate()
    {
        var curMoveInput = movementAction.ControlMap.PlayerMovement.ReadValue<Vector3>(); 
        SystemAPI.SetSingleton(new PlayerMoveInput { value = curMoveInput });
    }

    protected override void OnStopRunning()
    {
        movementAction.ControlMap.PlayerDash.performed -= OnPlayerDash;
        movementAction.ControlMap.PlayerAttack.performed -= OnPlayerAttack;
        movementAction.ControlMap.PlayerSpecial.performed -= OnPlayerSpecial;
        movementAction.ControlMap.PlayerCast.performed -= OnPlayerCast;
        movementAction.ControlMap.PlayerCall.performed -= OnPlayerCall;
        movementAction.ControlMap.PlayerInteract.performed -= OnPlayerInteract;
        movementAction.ControlMap.PlayerGift.performed -= OnPlayerGift;
        movementAction.ControlMap.PlayerBooninfo.performed -= OnPlayerBooninfo;
        movementAction.ControlMap.PlayerOpenCodex.performed -= OnPlayerOpenCodex;
        movementAction.ControlMap.PlayerSummon.performed -= OnPlayerSummon;
        movementAction.ControlMap.PlayerReload.performed -= OnPlayerReload;
        movementAction.ControlMap.PlayerScreenCapture.performed -= OnPlayerScreenCapture;
        movementAction.Disable();
    }

    private void OnPlayerDash(InputAction.CallbackContext obj)
    {
        SystemAPI.SetSingleton(new PlayerDashInput { value = true });
    }

    private void OnPlayerAttack(InputAction.CallbackContext obj)
    {
        SystemAPI.SetSingleton(new PlayerAttackInput { value = true, position = Mouse.current.position.ReadValue()});
    }

    private void OnPlayerSpecial(InputAction.CallbackContext obj)
    {
        SystemAPI.SetSingleton(new PlayerSpecialInput { value = true });
    }

    private void OnPlayerCast(InputAction.CallbackContext obj)
    {
        SystemAPI.SetSingleton(new PlayerCastInput { value = true });
    }

    private void OnPlayerCall(InputAction.CallbackContext obj)
    {
        SystemAPI.SetSingleton(new PlayerCallInput { value = true });
    }

    private void OnPlayerInteract(InputAction.CallbackContext obj)
    {
        SystemAPI.SetSingleton(new PlayerInteractInput { value = true });
    }

    private void OnPlayerGift(InputAction.CallbackContext obj)
    {
        SystemAPI.SetSingleton(new PlayerGiftInput { value = true });
    }

    private void OnPlayerBooninfo(InputAction.CallbackContext obj)
    {
        SystemAPI.SetSingleton(new PlayerBooninfoInput { value = true });
    }

    private void OnPlayerOpenCodex(InputAction.CallbackContext obj)
    {
        SystemAPI.SetSingleton(new PlayerOpenCodexInput { value = true });
    }

    private void OnPlayerSummon(InputAction.CallbackContext obj)
    {
        SystemAPI.SetSingleton(new PlayerSummonInput { value = true });
    }

    private void OnPlayerReload(InputAction.CallbackContext obj)
    {
        SystemAPI.SetSingleton(new PlayerReloadInput { value = true });
    }

    private void OnPlayerScreenCapture(InputAction.CallbackContext obj)
    {
        SystemAPI.SetSingleton(new PlayerScreenCaptureInput { value = true });
    }
}
