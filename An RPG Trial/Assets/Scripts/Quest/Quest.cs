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
    public Item reward;

    public void SetQuestActive()
    {
        isQuestActive = true;
    }

    public virtual bool EvaluateQuest(GameObject objectToEvaluate)
    {
        if (Completed)
        { return true; }
        return false;
    }
    public void Complete()
    {
        isQuestActive = false;
        Completed = true;
    }
}
