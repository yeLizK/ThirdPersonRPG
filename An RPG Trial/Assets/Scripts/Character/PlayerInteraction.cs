using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private static PlayerInteraction _instance;
    public static PlayerInteraction Instance { get { return _instance; } }
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
        GameObject collectedObject = CameraRaycast.Instance.objectHit.gameObject;
        if(QuestManager.Instance.activeQuest.questType == Quest.QuestType.gatherObject)
        {
            if(QuestManager.Instance.activeQuest.EvaluateQuest(collectedObject))
            {
                QuestManager.Instance.CompleteQuest();
            }
        }
        collectedObject.GetComponent<Collectable>().CollectObject();
    }
}
