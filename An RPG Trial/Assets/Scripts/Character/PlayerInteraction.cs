using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private static PlayerInteraction _instance;
    public static PlayerInteraction Instance { get { return _instance; } }

    [HideInInspector] public bool isCharInCollectableRange, isCharInNPCRange, isCharIdle, isCharWalking, isCharRunning;
    [SerializeField] public GameObject interactedObject;

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
    public void CollectObject()
    {
        if(QuestManager.Instance.activeQuest != null)
        {
            if (QuestManager.Instance.activeQuest.EvaluateQuest(interactedObject))
            {
                QuestManager.Instance.CompleteQuest();
            }
        }
        interactedObject.GetComponent<Collectable>().CollectObject();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "NPC")
        {
            InGameUIManager.Instance.OpenClickToTalkText();
            isCharInNPCRange = true;
            interactedObject = other.gameObject;
        }
        else if (other.gameObject.tag == "Collectable")
        {
            InGameUIManager.Instance.OpenClicktoCollectText();
            isCharInCollectableRange = true;
            interactedObject = other.gameObject;

        }
        interactedObject = other.gameObject;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "NPC")
        {
            InGameUIManager.Instance.OpenClickToTalkText();
            isCharInNPCRange = true;
        }
        else if (other.gameObject.tag == "Collectable")
        {
            InGameUIManager.Instance.OpenClicktoCollectText();
            isCharInCollectableRange = true;
            interactedObject = other.gameObject;

        }
        interactedObject = other.gameObject;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "NPC")
        {
            InGameUIManager.Instance.CloseInteractionText();
            CinemachineCameraManager.Instance.ExitDialogueMode();
            isCharInNPCRange = false;

        }
        else if (other.gameObject.tag == "Collectable")
        {
            isCharInCollectableRange = false;

        }
        interactedObject = null;
        InGameUIManager.Instance.CloseInteractionText();
    }


}
