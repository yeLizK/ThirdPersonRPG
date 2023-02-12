using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

[RequireComponent(typeof(CharacterController))]
public class CharacterMovement : MonoBehaviour , IDataPersistence
{
    private static CharacterMovement _instance;
    public static CharacterMovement Instance { get { return _instance; } }

    private Vector2 inputVector;
    private Vector3 movementVector;

    private Vector3 startingRotation;

    [SerializeField]
    private float clampAngle = 70f;

    [SerializeField]
    private float MouseXSpeed , MouseYSpeed;

    private CharacterController charController;

    private void Awake()
    {
        if(_instance != null && _instance != this)
        {
            Destroy(_instance);
        }
        else
        {
            _instance = this;
        }
    }

    private void Start()
    {
        charController = this.gameObject.GetComponent<CharacterController>();
    }

    public void LoadData(GameData data)
    {
        this.transform.position = data.playerTransform;
    }
    public void SaveData(ref GameData data)
    {
        data.playerTransform = this.transform.position;
    }

    private void Update()
    {
        inputVector = InputManager.Instance.GetPlayerInputs();
        movementVector = new Vector3(inputVector.y, 0, -inputVector.x);
        movementVector = transform.forward * movementVector.x + -transform.right * movementVector.z;
        movementVector.y = 0f;

        Vector2 deltaInput = InputManager.Instance.GetMouseDelta();
        startingRotation.x += deltaInput.x * Time.deltaTime;
        startingRotation.y += deltaInput.y * Time.deltaTime;
        startingRotation.y = Mathf.Clamp(startingRotation.y, -clampAngle, clampAngle);
        transform.rotation = Quaternion.Euler(-startingRotation.y*MouseYSpeed, startingRotation.x*MouseXSpeed, 0f);
        charController.Move(movementVector * Time.deltaTime * 2f);

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "CloseGate")
        {
            TutorialManager.Instance.CloseTutorialGate();
        }
    }
}
