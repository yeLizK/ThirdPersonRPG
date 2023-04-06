using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class NPCQuest : MonoBehaviour
{
    [Header("Quest")]
    public QuestSO questList;
    [SerializeField] private bool isNPCQuestActive;
    public Quest activeQuest;
    [SerializeField] private float newQuestWaitTime = 10f;

    public CinemachineVirtualCamera NPCFocusCam;
    public GameObject QuestIndicator;

    private void Start()
    {
        isNPCQuestActive = false;
    }

    private void Update()
    {
        if(!isNPCQuestActive && activeQuest !=null && !activeQuest.Name.Equals(""))
        {
            QuestIndicator.SetActive(true);
        }
        else QuestIndicator.SetActive(false);

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
        if(CharacterManager.Instance.Inventory.itemList.Count>0 && quest.questObject !=null)
        {
            QuestManager.Instance.activeQuest.EvaluateQuest(quest.questObject);

        }
    }
    public void CompleteNPCQuest(Quest quest)
    {
        if (quest.Name.Equals(activeQuest.Name))
        {
            CharacterManager.Instance.Inventory.RemoveItem(activeQuest.itemType, activeQuest.goalCount);
            CharacterManager.Instance.Inventory.AddItem(activeQuest.reward);
            activeQuest.isRewardTaken = true;
            activeQuest.questDialogue.isDialogueFinished = true;
            activeQuest = null;
            isNPCQuestActive = false;
            QuestManager.Instance.CompleteQuest();
            StartCoroutine(AssignNewQuest());
        }

    }

    public IEnumerator AssignNewQuest()
    {
        yield return new WaitForSeconds(10.0f);
        QuestManager.Instance.AssignQuestToNPCs();

    }

}
