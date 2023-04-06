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
        playerInputs.CharacterControl.Move.performed += MovementCtx => CheckKeyPress();
        playerInputs.CharacterControl.Interact.performed += interactCtx => Interact();
        playerInputs.CharacterControl.Attack.performed += AttackCtx => ClickLeftMouse();
        playerInputs.CharacterControl.Attack.performed += ShieldCtx => ClickRightMouse();

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
        return playerInputs.CharacterControl.Move.ReadValue<Vector2>();
    }

    public Vector2 GetMouseDelta()
    {
        return playerInputs.CharacterControl.Look.ReadValue<Vector2>();
    }
    public void CheckKeyPress()
    {
        if(TutorialManager.Instance.IsTutorialActive())
        {
            if (playerInputs.CharacterControl.Move.ReadValue<Vector2>().y > 0.0f)
            {
                TutorialManager.Instance.PressW();
            }
            if (playerInputs.CharacterControl.Move.ReadValue<Vector2>().y < 0.0f)
            {
                TutorialManager.Instance.PressS();
            }
            if (playerInputs.CharacterControl.Move.ReadValue<Vector2>().x > 0.0f)
            {
                TutorialManager.Instance.PressD();
            }
            if (playerInputs.CharacterControl.Move.ReadValue<Vector2>().x < 0.0f)
            {
                TutorialManager.Instance.PressA();
            }
        }
    }

    public void ClickLeftMouse()
    {
        StartCoroutine(CharacterMovement.Instance.Attack());
    }
    public void ClickRightMouse()
    {
        CharacterMovement.Instance.isCharHoldingShield = true;
    }

    public void UnbindKeyboardEvent()
    {
        playerInputs.CharacterControl.Move.performed -= cnt => CheckKeyPress();
        playerInputs.CharacterControl.Attack.performed -= AttackCtx => ClickLeftMouse();
        playerInputs.CharacterControl.Attack.performed -= ShieldCtx => ClickRightMouse();
    }

    private void UnbindCollectEvent()
    {
        playerInputs.CharacterControl.Interact.performed -= interactCtx => Interact();

    }

    public void Interact()
    {
        if (!DialogueManager.Instance.isDialoguePlaying)
        {
            //CinemachineCameraManager.Instance.ExitDialogueMode();
            if (PlayerInteraction.Instance.isCharInCollectableRange)
            {
                PlayerInteraction.Instance.CollectObject();
            }
            else if (PlayerInteraction.Instance.isCharInNPCRange)
            {
                if(PlayerInteraction.Instance.interactedObject.GetComponent<NPCQuest>().activeQuest !=null && !PlayerInteraction.Instance.interactedObject.GetComponent<NPCQuest>().activeQuest.Name.Equals(""))
                {
                    if (QuestManager.Instance.activeQuest == null || QuestManager.Instance.activeQuest.Name.Equals(""))
                    {
                        DialogueManager.Instance.EnterDialogueMode(PlayerInteraction.Instance.interactedObject.GetComponent<NPCQuest>().GetNPCDialog(), PlayerInteraction.Instance.interactedObject.GetComponent<NPCQuest>().NPCFocusCam);
                    }
                    else
                    {
                        DialogueManager.Instance.EvaluateDialog(PlayerInteraction.Instance.interactedObject.transform);
                    }
                }

            }
        }
        else
        {
            DialogueManager.Instance.ContinueStory();
            //CinemachineCameraManager.Instance.EnterDialogueMode();
        }

    }

}
