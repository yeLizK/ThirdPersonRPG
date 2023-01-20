using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class CharacterMovement : MonoBehaviour
{
    private Vector2 inputVector;
    private Vector3 movementVector;
    private Camera mainCamera;

    private CharacterController charController;

    private void Start()
    {
        mainCamera = Camera.main;
        charController = this.gameObject.GetComponent<CharacterController>();
    }

    private void Update()
    {
        inputVector = InputManager.Instance.GetPlayerInputs();
        movementVector = new Vector3(inputVector.y, 0, -inputVector.x);
        movementVector = mainCamera.transform.forward * movementVector.x + -mainCamera.transform.right * movementVector.z;
        movementVector.y = 0f;
        charController.Move(movementVector * Time.deltaTime * 2f);

    }
}
