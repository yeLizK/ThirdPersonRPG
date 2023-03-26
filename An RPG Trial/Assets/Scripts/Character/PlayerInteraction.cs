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
        if(interactedObject.tag.Equals("Collectable"))
        {
            interactedObject.GetComponent<Collectable>().CollectObject();

            if (QuestManager.Instance.activeQuest != null)
            {
                QuestManager.Instance.activeQuest.EvaluateQuest(interactedObject);
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals ("NPC"))
        {
            InGameUIManager.Instance.OpenClickToTalkText();
            isCharInNPCRange = true;
            interactedObject = other.gameObject;
        }
        else if (other.gameObject.tag.Equals( "Collectable"))
        {
            InGameUIManager.Instance.OpenClicktoCollectText();
            isCharInCollectableRange = true;
            interactedObject = other.gameObject;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag.Equals("NPC"))
        {
            InGameUIManager.Instance.OpenClickToTalkText();
            isCharInNPCRange = true;
            interactedObject = other.gameObject;
        }
        else if (other.gameObject.tag.Equals("Collectable"))
        {
            InGameUIManager.Instance.OpenClicktoCollectText();
            isCharInCollectableRange = true;
            interactedObject = other.gameObject;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("NPC"))
        {
            InGameUIManager.Instance.CloseInteractionText();
            isCharInNPCRange = false;

        }
        else if (other.gameObject.tag.Equals("Collectable"))
        {
            isCharInCollectableRange = false;

        }
        interactedObject = null;
        InGameUIManager.Instance.CloseInteractionText();
    }


}
