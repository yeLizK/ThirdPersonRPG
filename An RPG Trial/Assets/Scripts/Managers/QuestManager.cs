using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestManager : MonoBehaviour
{
    [SerializeField]
    private QuestSO questList;

    private bool anyActiveQuest; //returns true if there is an active quest

    [SerializeField]
    private TMP_Text questName, questDescription;

    private Quest activeQuest;


    private void Start()
    {
        anyActiveQuest = false;
        activeQuest = null;
        if(!anyActiveQuest)
        {
            AssignQuest();
        }
    }
    
    public void AssignQuest()
    {
        if (anyActiveQuest == false)
        {
            for (int i = 0; i < questList.gatheringQuest.Count; i++)
            {
                if (!questList.gatheringQuest[i].Completed)
                {
                    questList.gatheringQuest[i].isQuestActive = true;
                    activeQuest = questList.gatheringQuest[i];
                    questName.text = activeQuest.Name;
                    questDescription.text = activeQuest.Description;
                    return;
                }
            }
        }
    }



}
