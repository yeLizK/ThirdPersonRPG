using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public QuestSO questList;

    private bool anyActiveQuest; //returns true if there is an active quest



    private void Start()
    {
        anyActiveQuest = false;
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
                    return;
                }
            }
        }
    }



}
