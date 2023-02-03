using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/TutorialQuestSO")]
public class TutorialQuestSO : ScriptableObject
{
    public List<TutorialQuest> tutorialQuests = new List<TutorialQuest>();

}
