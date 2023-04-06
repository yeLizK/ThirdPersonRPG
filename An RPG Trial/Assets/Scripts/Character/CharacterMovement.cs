using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(CharacterController))]
public class CharacterMovement : MonoBehaviour , IDataPersistence
{
    private static CharacterMovement _instance;
    public static CharacterMovement Instance { get { return _instance; } }
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(_instance);
        }
        else
        {
            _instance = this;
        }
    }

    private Animator playerAnim;
    private CharacterController charController;

    private Vector2 look;

    private Vector3 startingRotation;
    private Vector2 moveVector;
    private Vector3 movementVector;
    private float gravityValue = -30f;
    private bool isAlive,isPlayerGotHit;

    public float rotationMagnitudeX = 0.1f;
    public float rotationMagnitudeY = 0.1f;

    [SerializeField] private float clampAngle = 70f;
    [SerializeField] private float MouseXSpeed , MouseYSpeed;
    [SerializeField] private float speedMultiplier;

    [HideInInspector] public bool isCharWalking, isCharAttacking, isCharHoldingShield;

    [SerializeField] private GameObject followTarget;

    private void Start()
    {
        playerAnim = GetComponentInChildren<Animator>();
        charController = this.gameObject.GetComponent<CharacterController>();
        speedMultiplier = 4f;
        isAlive = true;
    }

    public void LoadData(GameData data)
    {
        //All Loads are handled in GameSpecifics.cs
    }
    public void SaveData(ref GameData data)
    {
        data.playerTransform = this.transform.position;
    }

    public void OnMove(InputValue value)
    {
        moveVector = value.Get<Vector2>();
    }
    public void OnLook(InputValue value)
    {
        look = value.Get<Vector2>();
    }

    private void Update()
    {
        if (DialogueManager.Instance.isDialoguePlaying || !isAlive)
        {
            //Prevent player to move while in diaologue or is not alive
            this.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            return;
        }
        if (isAlive)
        {
            //Allow player to move
            this.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;

            movementVector = new Vector3(moveVector.y, 0, -moveVector.x);
            movementVector = transform.forward * movementVector.x + -transform.right * movementVector.z;
            movementVector.y = 0f;

            if (movementVector.magnitude > 0)
            {
                isCharWalking = true;

                playerAnim.SetBool("isCharIdle", false);
                playerAnim.SetBool("isRunning", true);
                playerAnim.SetBool("isCharAttacking", false);
            }

            else if (movementVector.magnitude <= 0 && !isCharAttacking)
            {
                isCharWalking = false;
                playerAnim.SetBool("isCharIdle", true);
                playerAnim.SetBool("isRunning", false);
                playerAnim.SetBool("isCharAttacking", false);
            }

            startingRotation.x += look.x * Time.deltaTime;
            startingRotation.y += look.y * Time.deltaTime;
            startingRotation.y = Mathf.Clamp(startingRotation.y, -clampAngle, clampAngle);
            transform.rotation = Quaternion.Euler(0f, startingRotation.x * MouseXSpeed, 0f);
            charController.Move(movementVector * Time.deltaTime * speedMultiplier);
        }
       
    }

    public IEnumerator Attack()
    {
        isCharAttacking = true;
        if(isCharAttacking)
        {
            playerAnim.SetBool("isCharIdle", false);
            playerAnim.SetBool("isRunning", false);
            playerAnim.SetBool("isCharAttacking", true);
        }
        
        yield return new WaitForSeconds(1.5f);
        isCharAttacking = false;
    }

    public void ReassingPlayerTransform()
    {
        transform.position = new Vector3(0, 0, 0);
    }

    public void ChangeAnimToHoldingSword()
    {
        playerAnim.runtimeAnimatorController = (RuntimeAnimatorController)Resources.Load("CharacterSwordAC");
    }
    public IEnumerator TakeDamage()
    {
        isPlayerGotHit = true;
        playerAnim.SetBool("isCharIdle", false);
        playerAnim.SetBool("isRunning", false);
        playerAnim.SetBool("isCharAttacking", false);
        playerAnim.SetBool("isCharDead", false);
        if(isPlayerGotHit)
        {
            playerAnim.SetBool("isCharTakingDamage", true);
        }
        yield return new WaitForSeconds(0.3f);
        isPlayerGotHit = false;
        playerAnim.SetBool("isCharTakingDamage", false);
    }
    public IEnumerator Die()
    {
        playerAnim.SetBool("isCharIdle", false);
        playerAnim.SetBool("isRunning", false);
        playerAnim.SetBool("isCharAttacking", false);
        playerAnim.SetBool("isCharTakingDamage", false);
        if(isAlive)
        {
            playerAnim.SetBool("isCharDead", true);
            isAlive = false;
        }
        yield return new WaitForSeconds(1f);
        playerAnim.SetBool("isCharDead", false);

    }
}
