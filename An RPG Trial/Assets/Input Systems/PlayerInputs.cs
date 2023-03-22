//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/Input Systems/PlayerInputs.inputactions
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

public partial class @PlayerInputs : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputs()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputs"",
    ""maps"": [
        {
            ""name"": ""CharacterControl"",
            ""id"": ""07ed8c1f-813b-4211-8492-820bf7b54026"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""e019095c-8542-4c5b-9d8b-fd782f3b8cc5"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""CameraMovement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""23a48bda-8ae3-4750-ba8a-52f252064607"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""45b03726-87c1-4455-9891-d510989d8156"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Value"",
                    ""id"": ""e1fc7614-a2cd-42e1-ae59-1fc193b37ab9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Value"",
                    ""id"": ""13c1a095-84ed-4c41-9504-b72ec86e8e0c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""HoldShield"",
                    ""type"": ""Value"",
                    ""id"": ""4e2f7d0a-5f11-4be8-9e5d-e6c0982d13a4"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""42a5c616-a8be-403e-99ad-48437c4fd2db"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""98298e4f-a99b-49b8-9896-0775788015a7"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""49c511cd-3b65-4e79-99f5-4527e1410ffc"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""05052019-eef4-4a13-97d6-0cd085eeb6be"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""319ac34b-359d-4300-9fae-b25cb7ff77ba"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""18fd82b8-2205-429e-ae85-4b017bbdf6ae"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3b444ed8-9922-454e-beb2-9b3ffce86521"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5ca404e0-de0d-4806-a3c9-cc5a973a2661"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c1adf4d4-7d7a-40c7-a7c6-4707c76b8587"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4ffaadbb-3110-46ce-b3dd-6aeb0145c3b1"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HoldShield"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // CharacterControl
        m_CharacterControl = asset.FindActionMap("CharacterControl", throwIfNotFound: true);
        m_CharacterControl_Movement = m_CharacterControl.FindAction("Movement", throwIfNotFound: true);
        m_CharacterControl_CameraMovement = m_CharacterControl.FindAction("CameraMovement", throwIfNotFound: true);
        m_CharacterControl_Interact = m_CharacterControl.FindAction("Interact", throwIfNotFound: true);
        m_CharacterControl_Jump = m_CharacterControl.FindAction("Jump", throwIfNotFound: true);
        m_CharacterControl_Attack = m_CharacterControl.FindAction("Attack", throwIfNotFound: true);
        m_CharacterControl_HoldShield = m_CharacterControl.FindAction("HoldShield", throwIfNotFound: true);
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

    // CharacterControl
    private readonly InputActionMap m_CharacterControl;
    private ICharacterControlActions m_CharacterControlActionsCallbackInterface;
    private readonly InputAction m_CharacterControl_Movement;
    private readonly InputAction m_CharacterControl_CameraMovement;
    private readonly InputAction m_CharacterControl_Interact;
    private readonly InputAction m_CharacterControl_Jump;
    private readonly InputAction m_CharacterControl_Attack;
    private readonly InputAction m_CharacterControl_HoldShield;
    public struct CharacterControlActions
    {
        private @PlayerInputs m_Wrapper;
        public CharacterControlActions(@PlayerInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_CharacterControl_Movement;
        public InputAction @CameraMovement => m_Wrapper.m_CharacterControl_CameraMovement;
        public InputAction @Interact => m_Wrapper.m_CharacterControl_Interact;
        public InputAction @Jump => m_Wrapper.m_CharacterControl_Jump;
        public InputAction @Attack => m_Wrapper.m_CharacterControl_Attack;
        public InputAction @HoldShield => m_Wrapper.m_CharacterControl_HoldShield;
        public InputActionMap Get() { return m_Wrapper.m_CharacterControl; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CharacterControlActions set) { return set.Get(); }
        public void SetCallbacks(ICharacterControlActions instance)
        {
            if (m_Wrapper.m_CharacterControlActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_CharacterControlActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_CharacterControlActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_CharacterControlActionsCallbackInterface.OnMovement;
                @CameraMovement.started -= m_Wrapper.m_CharacterControlActionsCallbackInterface.OnCameraMovement;
                @CameraMovement.performed -= m_Wrapper.m_CharacterControlActionsCallbackInterface.OnCameraMovement;
                @CameraMovement.canceled -= m_Wrapper.m_CharacterControlActionsCallbackInterface.OnCameraMovement;
                @Interact.started -= m_Wrapper.m_CharacterControlActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_CharacterControlActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_CharacterControlActionsCallbackInterface.OnInteract;
                @Jump.started -= m_Wrapper.m_CharacterControlActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_CharacterControlActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_CharacterControlActionsCallbackInterface.OnJump;
                @Attack.started -= m_Wrapper.m_CharacterControlActionsCallbackInterface.OnAttack;
                @Attack.performed -= m_Wrapper.m_CharacterControlActionsCallbackInterface.OnAttack;
                @Attack.canceled -= m_Wrapper.m_CharacterControlActionsCallbackInterface.OnAttack;
                @HoldShield.started -= m_Wrapper.m_CharacterControlActionsCallbackInterface.OnHoldShield;
                @HoldShield.performed -= m_Wrapper.m_CharacterControlActionsCallbackInterface.OnHoldShield;
                @HoldShield.canceled -= m_Wrapper.m_CharacterControlActionsCallbackInterface.OnHoldShield;
            }
            m_Wrapper.m_CharacterControlActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @CameraMovement.started += instance.OnCameraMovement;
                @CameraMovement.performed += instance.OnCameraMovement;
                @CameraMovement.canceled += instance.OnCameraMovement;
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Attack.started += instance.OnAttack;
                @Attack.performed += instance.OnAttack;
                @Attack.canceled += instance.OnAttack;
                @HoldShield.started += instance.OnHoldShield;
                @HoldShield.performed += instance.OnHoldShield;
                @HoldShield.canceled += instance.OnHoldShield;
            }
        }
    }
    public CharacterControlActions @CharacterControl => new CharacterControlActions(this);
    public interface ICharacterControlActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnCameraMovement(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
        void OnHoldShield(InputAction.CallbackContext context);
    }
}
