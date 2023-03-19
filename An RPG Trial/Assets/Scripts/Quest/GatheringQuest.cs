using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GatheringQuest : Quest
{
    [Header("Gathering Quest")]
    public int goalCount;
    public Item.ItemType itemType;

    public override bool EvaluateQuest(GameObject objectToEvalaute)
    {
        if(objectToEvalaute.GetComponent<Collectable>().itemType == itemType && this.isQuestActive)
        {
            if (Inventory.Instance.ReturnItemAmount(itemType) >= goalCount)
            {
                Complete();
                return true;
            }
        }
        return false;
    }

}
