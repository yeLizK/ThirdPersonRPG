using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest
{
    public string Name;
    public string Description;
    public bool Completed;
    public bool isQuestActive;
    public bool isQuestAvailable;
    public enum QuestType { gatherObject, talkToNPC, ClickCertainObject }

    public QuestType questType;
    public GameObject questObject;

    [Header("Gathering Quest")]
    public int goalCount;
    public Item.ItemType itemType;

    [Header("Dialog")]
    public Dialogue questDialogue;

    [Header("Reward")]
    public Item reward;
    public bool isRewardTaken;

    public void SetQuestActive()
    {
        isQuestActive = true;
    }

    public virtual bool EvaluateQuest(GameObject objectToEvaluate)
    {
        if (objectToEvaluate.GetComponent<Collectable>().itemType == itemType && this.isQuestActive)
        {
            if (CharacterManager.Instance.Inventory.ReturnItemAmount(itemType) >= goalCount)
            {
                Complete();
                return true;
            }
        }
        return false;
    }

    public void Complete()
    {
        isQuestActive = false;
        Completed = true;
    }
}
