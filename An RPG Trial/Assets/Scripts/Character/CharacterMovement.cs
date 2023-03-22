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
    private float jumpHeight = 1.0f;
    private float gravityValue = -30f;
    private bool isPlayerGrounded;

    private Vector3 startingRotation;

    [SerializeField]
    private float clampAngle = 70f;

    [SerializeField]
    private float MouseXSpeed , MouseYSpeed;
    [SerializeField] private float speedMultiplier;

    private CharacterController charController;

    [HideInInspector] public bool isCharWalking, isCharJumping, isCharAttacking, isCharHoldingShield;

    [SerializeField] public Animator charAnim;

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
        speedMultiplier = 4f;
    }

    public void LoadData(GameData data)
    {
        this.transform.position = new Vector3(data.playerTransform.x,0f,data.playerTransform.z);
    }
    public void SaveData(ref GameData data)
    {
        data.playerTransform = this.transform.position;
    }

    private void Update()
    {
        if(DialogueManager.Instance.isDialoguePlaying)
        { return; }
        isPlayerGrounded = charController.isGrounded;
        inputVector = InputManager.Instance.GetPlayerInputs();
        movementVector = new Vector3(inputVector.y, 0, -inputVector.x);
        movementVector = transform.forward * movementVector.x + -transform.right * movementVector.z;
        movementVector.y = 0f;

        if (isCharAttacking && isPlayerGrounded)
        {
            charAnim.SetBool("isCharIdle", false);
            charAnim.SetBool("isCharJumping", false);
            charAnim.SetBool("isRunning", false);
            charAnim.SetBool("isCharAttacking", true);
        }

        if (isCharJumping && isPlayerGrounded)
        {
            movementVector.y = Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            charAnim.SetBool("isCharJumping", true);
            charAnim.SetBool("isCharIdle", false);
            charAnim.SetBool("isRunning", false);
            charAnim.SetBool("isCharAttacking", false);


        }
        if (isCharAttacking && isPlayerGrounded)
        {
            charAnim.SetBool("isCharIdle", false);
            charAnim.SetBool("isCharJumping", false);
            charAnim.SetBool("isRunning", false);
            charAnim.SetBool("isCharAttacking", true);
        }
        else if (movementVector.magnitude > 0 && isPlayerGrounded)
        {
            isCharWalking = true;
            isCharJumping = false;

            charAnim.SetBool("isCharIdle", false);
            charAnim.SetBool("isRunning", true);
            charAnim.SetBool("isCharJumping", false);
            charAnim.SetBool("isCharAttacking", false);


        }

        else if(movementVector.magnitude <=0 && isPlayerGrounded)
        {
            isCharWalking = false;
            isCharJumping = false;
            charAnim.SetBool("isCharIdle", true);
            charAnim.SetBool("isRunning", false);
            charAnim.SetBool("isCharJumping", false);
            charAnim.SetBool("isCharAttacking", false);


        }

        isCharJumping = false;
        isCharAttacking = false;

        movementVector.y += gravityValue * Time.deltaTime;
        Vector2 deltaInput = InputManager.Instance.GetMouseDelta();
        startingRotation.x += deltaInput.x * Time.deltaTime;
        startingRotation.y += deltaInput.y * Time.deltaTime;
        startingRotation.y = Mathf.Clamp(startingRotation.y, -clampAngle, clampAngle);
        transform.rotation = Quaternion.Euler(0f, startingRotation.x*MouseXSpeed, 0f);
        charController.Move(movementVector * Time.deltaTime * speedMultiplier);
    }

    public void ReassingPlayerTransform()
    {
        transform.position = new Vector3(0, 0, 0);
    }

    public void ChangeAnimToHoldingSword()
    {
        charAnim.runtimeAnimatorController = (RuntimeAnimatorController)Resources.Load("CharacterSwordAC");
    }
}
