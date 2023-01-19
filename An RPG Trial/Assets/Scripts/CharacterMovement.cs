using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour
{
    private PlayerInputs input;
    private Vector2 inputVector;
    private Vector3 movementVector;
    private Vector2 cameraAxis;


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

        cameraAxis = input.CharacterControl.CameraMovement.ReadValue<Vector2>();
        this.gameObject.transform.rotation = Quaternion.Euler(new Vector3(-cameraAxis.y, cameraAxis.x, 0));
    }

    private void OnEnable()
    {
        if(input ==null)
        {
            input = new PlayerInputs();
        }
        input.CharacterControl.Enable();
    }
    private void OnDisable()
    {
        input.CharacterControl.Disable();
    }
}
