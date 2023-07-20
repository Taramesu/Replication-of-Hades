//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.5.1
//     from Assets/MovementAction.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @MovementAction: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @MovementAction()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""MovementAction"",
    ""maps"": [
        {
            ""name"": ""ControlMap"",
            ""id"": ""6881f377-3807-4438-b8c7-070a8b7f746b"",
            ""actions"": [
                {
                    ""name"": ""PlayerMovement"",
                    ""type"": ""Value"",
                    ""id"": ""539fbc28-31fc-430b-9b9c-512d22b7ec36"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""PlayerDash"",
                    ""type"": ""Button"",
                    ""id"": ""44df9655-d080-430d-9ffd-4d19ce3ccac6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""PlayerAttack"",
                    ""type"": ""Button"",
                    ""id"": ""e3ac755d-d03f-4131-9831-1295732ee9b3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""PlayerSpecial"",
                    ""type"": ""Button"",
                    ""id"": ""e75189dd-bffa-48c5-8506-2c5c5ba356d3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""PlayerCast"",
                    ""type"": ""Button"",
                    ""id"": ""ca4d5088-8b21-4731-88df-b5cc28d5e4ed"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""PlayerCall"",
                    ""type"": ""Button"",
                    ""id"": ""e2a64863-6c81-48ba-b98f-115881b93738"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""PlayerInteract"",
                    ""type"": ""Button"",
                    ""id"": ""6f1e1fdf-34da-4a2e-9187-4f9d8640ba95"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""PlayerGift"",
                    ""type"": ""Button"",
                    ""id"": ""7611526f-4e79-4891-ba2c-c9774e25b240"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""PlayerBooninfo"",
                    ""type"": ""Button"",
                    ""id"": ""84ec6ff3-a866-47a8-acbd-be113f7fbcb3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""PlayerOpenCodex"",
                    ""type"": ""Button"",
                    ""id"": ""25a77f69-6c57-49b5-811d-411a1c4e404a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""PlayerSummon"",
                    ""type"": ""Button"",
                    ""id"": ""f3085ac9-c7c8-4f9a-936f-2331f122dc50"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""PlayerReload"",
                    ""type"": ""Button"",
                    ""id"": ""79c9b407-d4d8-4b60-93af-0f6993e3b7bd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""PlayerScreenCapture"",
                    ""type"": ""Button"",
                    ""id"": ""50bf2ad1-1fbd-45b5-a904-a7a839e8a63b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""e229e03b-fa41-4f26-b833-988cb69bd96b"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PlayerMovement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""08bac3fc-9c08-4d4e-a2df-e1fc978739d3"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PlayerMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""c2c42197-85c5-4665-bb20-e3c1456cc520"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PlayerMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""15b286b1-5592-4e65-a22a-f562afd3eb47"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PlayerMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""49837b22-1aa5-40c5-a2fd-432fe4224331"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PlayerMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""954e2c9c-bacf-48c8-8c3e-ff7d5177b1a9"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PlayerDash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""262745bd-b62d-4918-8c4f-001683d76d88"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PlayerAttack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3da3247c-13e7-4ba5-a5b7-e28b9e970d37"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PlayerSpecial"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2d35d07a-45c0-4cd3-8095-87035c56e3de"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PlayerCast"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c431d8fc-e27e-4106-8272-6c6cf988092e"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PlayerCall"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""18e8cdd6-a0d0-4c34-8bda-be04a8a208d3"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PlayerInteract"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""aaa2b35a-707e-43ce-9510-0bef951976cc"",
                    ""path"": ""<Keyboard>/g"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PlayerGift"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8ce50f1b-d346-4313-951b-49bc94422bba"",
                    ""path"": ""<Keyboard>/b"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PlayerBooninfo"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1a429a63-8d2a-46ff-8656-b97ee6accc6b"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PlayerOpenCodex"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""57f1413f-7084-4f60-a9fc-458c23c4efd1"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PlayerSummon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1794c9e6-1ef8-4bd2-be71-9e2df4e2fd77"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PlayerReload"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c81cafdf-f698-42a9-93e0-48f99c274862"",
                    ""path"": ""<Keyboard>/f11"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PlayerScreenCapture"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // ControlMap
        m_ControlMap = asset.FindActionMap("ControlMap", throwIfNotFound: true);
        m_ControlMap_PlayerMovement = m_ControlMap.FindAction("PlayerMovement", throwIfNotFound: true);
        m_ControlMap_PlayerDash = m_ControlMap.FindAction("PlayerDash", throwIfNotFound: true);
        m_ControlMap_PlayerAttack = m_ControlMap.FindAction("PlayerAttack", throwIfNotFound: true);
        m_ControlMap_PlayerSpecial = m_ControlMap.FindAction("PlayerSpecial", throwIfNotFound: true);
        m_ControlMap_PlayerCast = m_ControlMap.FindAction("PlayerCast", throwIfNotFound: true);
        m_ControlMap_PlayerCall = m_ControlMap.FindAction("PlayerCall", throwIfNotFound: true);
        m_ControlMap_PlayerInteract = m_ControlMap.FindAction("PlayerInteract", throwIfNotFound: true);
        m_ControlMap_PlayerGift = m_ControlMap.FindAction("PlayerGift", throwIfNotFound: true);
        m_ControlMap_PlayerBooninfo = m_ControlMap.FindAction("PlayerBooninfo", throwIfNotFound: true);
        m_ControlMap_PlayerOpenCodex = m_ControlMap.FindAction("PlayerOpenCodex", throwIfNotFound: true);
        m_ControlMap_PlayerSummon = m_ControlMap.FindAction("PlayerSummon", throwIfNotFound: true);
        m_ControlMap_PlayerReload = m_ControlMap.FindAction("PlayerReload", throwIfNotFound: true);
        m_ControlMap_PlayerScreenCapture = m_ControlMap.FindAction("PlayerScreenCapture", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // ControlMap
    private readonly InputActionMap m_ControlMap;
    private List<IControlMapActions> m_ControlMapActionsCallbackInterfaces = new List<IControlMapActions>();
    private readonly InputAction m_ControlMap_PlayerMovement;
    private readonly InputAction m_ControlMap_PlayerDash;
    private readonly InputAction m_ControlMap_PlayerAttack;
    private readonly InputAction m_ControlMap_PlayerSpecial;
    private readonly InputAction m_ControlMap_PlayerCast;
    private readonly InputAction m_ControlMap_PlayerCall;
    private readonly InputAction m_ControlMap_PlayerInteract;
    private readonly InputAction m_ControlMap_PlayerGift;
    private readonly InputAction m_ControlMap_PlayerBooninfo;
    private readonly InputAction m_ControlMap_PlayerOpenCodex;
    private readonly InputAction m_ControlMap_PlayerSummon;
    private readonly InputAction m_ControlMap_PlayerReload;
    private readonly InputAction m_ControlMap_PlayerScreenCapture;
    public struct ControlMapActions
    {
        private @MovementAction m_Wrapper;
        public ControlMapActions(@MovementAction wrapper) { m_Wrapper = wrapper; }
        public InputAction @PlayerMovement => m_Wrapper.m_ControlMap_PlayerMovement;
        public InputAction @PlayerDash => m_Wrapper.m_ControlMap_PlayerDash;
        public InputAction @PlayerAttack => m_Wrapper.m_ControlMap_PlayerAttack;
        public InputAction @PlayerSpecial => m_Wrapper.m_ControlMap_PlayerSpecial;
        public InputAction @PlayerCast => m_Wrapper.m_ControlMap_PlayerCast;
        public InputAction @PlayerCall => m_Wrapper.m_ControlMap_PlayerCall;
        public InputAction @PlayerInteract => m_Wrapper.m_ControlMap_PlayerInteract;
        public InputAction @PlayerGift => m_Wrapper.m_ControlMap_PlayerGift;
        public InputAction @PlayerBooninfo => m_Wrapper.m_ControlMap_PlayerBooninfo;
        public InputAction @PlayerOpenCodex => m_Wrapper.m_ControlMap_PlayerOpenCodex;
        public InputAction @PlayerSummon => m_Wrapper.m_ControlMap_PlayerSummon;
        public InputAction @PlayerReload => m_Wrapper.m_ControlMap_PlayerReload;
        public InputAction @PlayerScreenCapture => m_Wrapper.m_ControlMap_PlayerScreenCapture;
        public InputActionMap Get() { return m_Wrapper.m_ControlMap; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ControlMapActions set) { return set.Get(); }
        public void AddCallbacks(IControlMapActions instance)
        {
            if (instance == null || m_Wrapper.m_ControlMapActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_ControlMapActionsCallbackInterfaces.Add(instance);
            @PlayerMovement.started += instance.OnPlayerMovement;
            @PlayerMovement.performed += instance.OnPlayerMovement;
            @PlayerMovement.canceled += instance.OnPlayerMovement;
            @PlayerDash.started += instance.OnPlayerDash;
            @PlayerDash.performed += instance.OnPlayerDash;
            @PlayerDash.canceled += instance.OnPlayerDash;
            @PlayerAttack.started += instance.OnPlayerAttack;
            @PlayerAttack.performed += instance.OnPlayerAttack;
            @PlayerAttack.canceled += instance.OnPlayerAttack;
            @PlayerSpecial.started += instance.OnPlayerSpecial;
            @PlayerSpecial.performed += instance.OnPlayerSpecial;
            @PlayerSpecial.canceled += instance.OnPlayerSpecial;
            @PlayerCast.started += instance.OnPlayerCast;
            @PlayerCast.performed += instance.OnPlayerCast;
            @PlayerCast.canceled += instance.OnPlayerCast;
            @PlayerCall.started += instance.OnPlayerCall;
            @PlayerCall.performed += instance.OnPlayerCall;
            @PlayerCall.canceled += instance.OnPlayerCall;
            @PlayerInteract.started += instance.OnPlayerInteract;
            @PlayerInteract.performed += instance.OnPlayerInteract;
            @PlayerInteract.canceled += instance.OnPlayerInteract;
            @PlayerGift.started += instance.OnPlayerGift;
            @PlayerGift.performed += instance.OnPlayerGift;
            @PlayerGift.canceled += instance.OnPlayerGift;
            @PlayerBooninfo.started += instance.OnPlayerBooninfo;
            @PlayerBooninfo.performed += instance.OnPlayerBooninfo;
            @PlayerBooninfo.canceled += instance.OnPlayerBooninfo;
            @PlayerOpenCodex.started += instance.OnPlayerOpenCodex;
            @PlayerOpenCodex.performed += instance.OnPlayerOpenCodex;
            @PlayerOpenCodex.canceled += instance.OnPlayerOpenCodex;
            @PlayerSummon.started += instance.OnPlayerSummon;
            @PlayerSummon.performed += instance.OnPlayerSummon;
            @PlayerSummon.canceled += instance.OnPlayerSummon;
            @PlayerReload.started += instance.OnPlayerReload;
            @PlayerReload.performed += instance.OnPlayerReload;
            @PlayerReload.canceled += instance.OnPlayerReload;
            @PlayerScreenCapture.started += instance.OnPlayerScreenCapture;
            @PlayerScreenCapture.performed += instance.OnPlayerScreenCapture;
            @PlayerScreenCapture.canceled += instance.OnPlayerScreenCapture;
        }

        private void UnregisterCallbacks(IControlMapActions instance)
        {
            @PlayerMovement.started -= instance.OnPlayerMovement;
            @PlayerMovement.performed -= instance.OnPlayerMovement;
            @PlayerMovement.canceled -= instance.OnPlayerMovement;
            @PlayerDash.started -= instance.OnPlayerDash;
            @PlayerDash.performed -= instance.OnPlayerDash;
            @PlayerDash.canceled -= instance.OnPlayerDash;
            @PlayerAttack.started -= instance.OnPlayerAttack;
            @PlayerAttack.performed -= instance.OnPlayerAttack;
            @PlayerAttack.canceled -= instance.OnPlayerAttack;
            @PlayerSpecial.started -= instance.OnPlayerSpecial;
            @PlayerSpecial.performed -= instance.OnPlayerSpecial;
            @PlayerSpecial.canceled -= instance.OnPlayerSpecial;
            @PlayerCast.started -= instance.OnPlayerCast;
            @PlayerCast.performed -= instance.OnPlayerCast;
            @PlayerCast.canceled -= instance.OnPlayerCast;
            @PlayerCall.started -= instance.OnPlayerCall;
            @PlayerCall.performed -= instance.OnPlayerCall;
            @PlayerCall.canceled -= instance.OnPlayerCall;
            @PlayerInteract.started -= instance.OnPlayerInteract;
            @PlayerInteract.performed -= instance.OnPlayerInteract;
            @PlayerInteract.canceled -= instance.OnPlayerInteract;
            @PlayerGift.started -= instance.OnPlayerGift;
            @PlayerGift.performed -= instance.OnPlayerGift;
            @PlayerGift.canceled -= instance.OnPlayerGift;
            @PlayerBooninfo.started -= instance.OnPlayerBooninfo;
            @PlayerBooninfo.performed -= instance.OnPlayerBooninfo;
            @PlayerBooninfo.canceled -= instance.OnPlayerBooninfo;
            @PlayerOpenCodex.started -= instance.OnPlayerOpenCodex;
            @PlayerOpenCodex.performed -= instance.OnPlayerOpenCodex;
            @PlayerOpenCodex.canceled -= instance.OnPlayerOpenCodex;
            @PlayerSummon.started -= instance.OnPlayerSummon;
            @PlayerSummon.performed -= instance.OnPlayerSummon;
            @PlayerSummon.canceled -= instance.OnPlayerSummon;
            @PlayerReload.started -= instance.OnPlayerReload;
            @PlayerReload.performed -= instance.OnPlayerReload;
            @PlayerReload.canceled -= instance.OnPlayerReload;
            @PlayerScreenCapture.started -= instance.OnPlayerScreenCapture;
            @PlayerScreenCapture.performed -= instance.OnPlayerScreenCapture;
            @PlayerScreenCapture.canceled -= instance.OnPlayerScreenCapture;
        }

        public void RemoveCallbacks(IControlMapActions instance)
        {
            if (m_Wrapper.m_ControlMapActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IControlMapActions instance)
        {
            foreach (var item in m_Wrapper.m_ControlMapActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_ControlMapActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public ControlMapActions @ControlMap => new ControlMapActions(this);
    public interface IControlMapActions
    {
        void OnPlayerMovement(InputAction.CallbackContext context);
        void OnPlayerDash(InputAction.CallbackContext context);
        void OnPlayerAttack(InputAction.CallbackContext context);
        void OnPlayerSpecial(InputAction.CallbackContext context);
        void OnPlayerCast(InputAction.CallbackContext context);
        void OnPlayerCall(InputAction.CallbackContext context);
        void OnPlayerInteract(InputAction.CallbackContext context);
        void OnPlayerGift(InputAction.CallbackContext context);
        void OnPlayerBooninfo(InputAction.CallbackContext context);
        void OnPlayerOpenCodex(InputAction.CallbackContext context);
        void OnPlayerSummon(InputAction.CallbackContext context);
        void OnPlayerReload(InputAction.CallbackContext context);
        void OnPlayerScreenCapture(InputAction.CallbackContext context);
    }
}
