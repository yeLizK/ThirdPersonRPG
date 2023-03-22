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
        playerInputs.CharacterControl.Movement.performed += ctx => CheckKeyPress();
        playerInputs.CharacterControl.Interact.performed += interactCtx => Interact();
        playerInputs.CharacterControl.Jump.performed += jumpCtx => CheckIfPlayerJumped();
    }

    private void OnEnable()
    {
        playerInputs.Enable();
    }

    private void OnDisable()
    {
        UnbindKeyboardEvent();
        UnbindCollectEvent();
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
        if(TutorialManager.Instance.IsTutorialActive())
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

    public void CheckIfPlayerJumped()
    {
        CharacterMovement.Instance.isCharJumping = true;
    }    

    public void UnbindKeyboardEvent()
    {
        playerInputs.CharacterControl.Movement.performed -= cnt => CheckKeyPress();
        playerInputs.CharacterControl.Jump.performed -= jumpCtx => CheckIfPlayerJumped();
    }

    private void UnbindCollectEvent()
    {
        playerInputs.CharacterControl.Interact.performed -= interactCtx => Interact();

    }

    public void Interact()
    {
        if (!DialogueManager.Instance.isDialoguePlaying)
        {
            CinemachineCameraManager.Instance.ExitDialogueMode();
            if (PlayerInteraction.Instance.isCharInCollectableRange)
            {
                PlayerInteraction.Instance.CollectObject();
            }
            else if (PlayerInteraction.Instance.isCharInNPCRange)
            {
                if (QuestManager.Instance.activeQuest == null || QuestManager.Instance.activeQuest.Name.Equals(""))
                {
                    DialogueManager.Instance.EnterDialogueMode(PlayerInteraction.Instance.interactedObject.GetComponent<NPCQuest>().GetNPCDialog());
                    CinemachineCameraManager.Instance.EnterDialogueMode();
                }
                else
                {
                    DialogueManager.Instance.EvaluateDialog(PlayerInteraction.Instance.interactedObject.transform);
                    CinemachineCameraManager.Instance.EnterDialogueMode();
                }

            }
        }
        else
        {
            DialogueManager.Instance.ContinueStory();
            CinemachineCameraManager.Instance.EnterDialogueMode();
        }

    }

}
