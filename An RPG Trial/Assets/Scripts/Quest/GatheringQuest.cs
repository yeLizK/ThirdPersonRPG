using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GatheringQuest : Quest
{
    [Header("Gathering Quest")]
    public int currentCount;
    public int goalCount;

    public override bool EvaluateQuest(GameObject objectToEvalaute)
    {
        if(questObject.name.Equals(objectToEvalaute.name) && this.isQuestActive)
        {
            IncrementQuestCount();
            Debug.Log(currentCount);
            if (currentCount >= goalCount)
            {
                Complete();
                return true;
            }
        }
       
        return false;
    }
    public void IncrementQuestCount()
    {
        currentCount++;
    }

}
