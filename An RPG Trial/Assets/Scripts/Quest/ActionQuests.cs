using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ActionQuests : Quest
{

    public enum QuestType {KeyPress, TalkToNPC }

    public QuestType questType;
    public override bool EvaluateQuest()
    {
        if(questType == QuestType.KeyPress)
        {
            return PressKeyQuestEvaluate();
        }
        else if(questType == QuestType.TalkToNPC)
        {
            return TalkToNPCEvaluate();
        }
        return false;
    }

    private bool PressKeyQuestEvaluate()
    {
        return false;
    }
    private bool TalkToNPCEvaluate()
    {
        return false;
    }
}
