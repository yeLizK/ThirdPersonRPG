using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCQuest : MonoBehaviour
{
    [Header("Ink JSON")]
    public List<Dialogue> dialogueList;
    private Dialogue currentDialogue;


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
        foreach (Dialogue dialogue in dialogueList)
        {
            if (!dialogue.isDialogueFinished)
            {
                currentDialogue = dialogue;
                return dialogue.inkJSON;
            }
        }
        return null;
    }

    public void AssignQuestToNPC(Quest quest)
    {
        this.activeQuest = quest;
        isNPCQuestActive = true;
    }
    public void CompleteNPCQuest(Quest quest)
    {
        if (quest.Name.Equals(activeQuest.Name))
        {
            Inventory.Instance.RemoveItem(activeQuest.itemType, activeQuest.goalCount);
            Inventory.Instance.AddItem(activeQuest.reward);
            currentDialogue.isDialogueFinished = true;
            activeQuest = null;
            isNPCQuestActive = false;
            QuestManager.Instance.CompleteQuest();
        }

    }

}
