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
}
