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
            AssignQuest();
        }
    }
    
    public void AssignQuest()
    {
        if (anyActiveQuest == false)
        {
            for(int i = 0; i <questList.quests.Count; i ++)
            {
                if (!questList.quests[i].Completed)
                {
                    questList.quests[i].isQuestActive = true;
                    activeQuest = questList.quests[i];
                    InGameUIManager.Instance.RefreshQuest();
                    return;
                }
            }
            
        }
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
