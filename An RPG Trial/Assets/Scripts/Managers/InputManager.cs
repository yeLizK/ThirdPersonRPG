using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private static InputManager _instance;
    public static InputManager Instance { get { return _instance; } }

    private PlayerInputs playerInputs;

    private void Awake()
    {
        if(_instance!= null && _instance!= this)
        {
            Destroy(this);
        }
        else
        {
            _instance = this;
        }
        playerInputs = new PlayerInputs();
        Cursor.visible = false;
        playerInputs.CharacterControl.Movement.performed += cnt => CheckKeyPress();
        playerInputs.CharacterControl.CameraMovement.performed += cameraCnt => CheckMouseMovement();

    }

    private void OnEnable()
    {
        playerInputs.Enable();
    }

    private void OnDisable()
    {
        playerInputs.Disable();
    }

    public Vector2 GetPlayerInputs()
    {
        return playerInputs.CharacterControl.Movement.ReadValue<Vector2>();
    }

    public Vector2 GetMouseDelta()
    {
        return playerInputs.CharacterControl.CameraMovement.ReadValue<Vector2>();
    }
    public void CheckKeyPress()
    {
        if(TutorialManager.Instance.isTutorialActive())
        {
            if (playerInputs.CharacterControl.Movement.ReadValue<Vector2>().y > 0.0f)
            {
                TutorialManager.Instance.PressW();
            }
            if (playerInputs.CharacterControl.Movement.ReadValue<Vector2>().y < 0.0f)
            {
                TutorialManager.Instance.PressS();
            }
            if (playerInputs.CharacterControl.Movement.ReadValue<Vector2>().x > 0.0f)
            {
                TutorialManager.Instance.PressD();
            }
            if (playerInputs.CharacterControl.Movement.ReadValue<Vector2>().x < 0.0f)
            {
                TutorialManager.Instance.PressA();
            }
        }
    }
    public void CheckMouseMovement()
    {
        if (TutorialManager.Instance.isTutorialActive())
        {
            if (playerInputs.CharacterControl.CameraMovement.ReadValue<Vector2>().x > 50f && playerInputs.CharacterControl.CameraMovement.ReadValue<Vector2>().y>50f)
                TutorialManager.Instance.MoveCamera();
        }
    }


    public void UnboundKeyboardEvent()
    {
        playerInputs.CharacterControl.Movement.performed -= cnt => CheckKeyPress();
    }

    public void UnboundCameraEvent()
    {
        playerInputs.CharacterControl.CameraMovement.performed -= cnt => CheckMouseMovement();

    }
}
