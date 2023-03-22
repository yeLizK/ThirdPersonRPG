using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCQuest : MonoBehaviour
{
    [Header("Quest")]
    public QuestSO questList;
    [SerializeField] private bool isNPCQuestActive;
    public Quest activeQuest;


    private void Start()
    {
        isNPCQuestActive = false;
    }

    public TextAsset GetNPCDialog()
    {
        if(!activeQuest.questDialogue.isDialogueFinished)
        {
            if (!activeQuest.questDialogue.isDialogueFinished)
            {
                return activeQuest.questDialogue.inkJSON;
            }
        }
        return null;
    }

    public void AssignQuestToNPC(Quest quest)
    {
        this.activeQuest = quest;
        quest.isQuestActive = true;
        isNPCQuestActive = true;
    }
    public void CompleteNPCQuest(Quest quest)
    {
        if (quest.Name.Equals(activeQuest.Name))
        {
            Inventory.Instance.RemoveItem(activeQuest.itemType, activeQuest.goalCount);
            Inventory.Instance.AddItem(activeQuest.reward);
            activeQuest.isRewardTaken = true;
            activeQuest.questDialogue.isDialogueFinished = true;
            activeQuest = null;
            isNPCQuestActive = false;
            QuestManager.Instance.CompleteQuest();
        }

    }

}
