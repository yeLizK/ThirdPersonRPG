using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/QuestSO")]
public class QuestSO : ScriptableObject
{
    public List<GatheringQuest> quests = new List<GatheringQuest>();

}
