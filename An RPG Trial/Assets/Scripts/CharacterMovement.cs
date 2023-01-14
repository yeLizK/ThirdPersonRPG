using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour
{
    private PlayerInputs input;
    private Vector2 inputVector;
    private Vector3 movementVector;

    private CharacterController charController;

    private void Awake()
    {
        input = new PlayerInputs();
        charController = this.gameObject.GetComponent<CharacterController>();
    }

    private void Update()
    {
        inputVector = input.CharacterControl.Movement.ReadValue<Vector2>();
        movementVector = new Vector3(inputVector.y, 0, -inputVector.x);
        charController.Move(movementVector * Time.deltaTime * 2f);

    }

    private void OnEnable()
    {
        input.CharacterControl.Enable();
    }
    private void OnDisable()
    {
        input.CharacterControl.Disable();
    }
}
