using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestManager : MonoBehaviour
{
    private static QuestManager _instance;
    public static QuestManager Instance { get { return _instance; } }

    [SerializeField]
    private QuestSO questList;

    private bool anyActiveQuest; //returns true if there is an active quest

    [HideInInspector]
    public Quest activeQuest;

    [HideInInspector]

    private void Awake()
    {
        if(_instance!=null &&_instance!=this)
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
        anyActiveQuest = false;
        activeQuest = null;
        if(!anyActiveQuest && !TutorialManager.Instance.IsTutorialActive())
        {
            AssignGatheringQuest();
        }
    }
    
    public void AssignGatheringQuest()
    {
        if (anyActiveQuest == false)
        {
            for (int i = 0; i < questList.gatheringQuest.Count; i++)
            {
                if (!questList.gatheringQuest[i].Completed)
                {
                    questList.gatheringQuest[i].isQuestActive = true;
                    activeQuest = questList.gatheringQuest[i];
                    InGameUIManager.Instance.RefreshQuest();
                    return;
                }
            }
        }
    }

    public void AssignActionQuest()
    {
        
    }

    public void CompleteQuest()
    {
        activeQuest.Complete();
        activeQuest = null;
        if (activeQuest == null)
        {
            InGameUIManager.Instance.EmptyQuestList();
        }
        else InGameUIManager.Instance.RefreshQuest();
        //AssignGatheringQuest();
    }

}
