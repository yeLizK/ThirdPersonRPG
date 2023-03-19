using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ActionQuests : Quest
{
    public GameObject questObject;
    public override bool EvaluateQuest(GameObject objectToEvaluate)
    {
        if(questObject.name.Equals(objectToEvaluate.name) )
        {
            Complete();
            return true;
        }
        return false;
    }

}
