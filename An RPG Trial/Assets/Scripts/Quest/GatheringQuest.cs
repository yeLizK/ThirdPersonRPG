using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GatheringQuest : Quest
{
    public int currentCount;
    public int goalCount;

    public override bool EvaluateQuest()
    {
        if(currentCount >= goalCount)
        {
            return true;
        }
        return false;
    }
}
