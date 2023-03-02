using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public bool isTutorialCompleted;
    public bool isTutorialWPressed;
    public bool isTutorialAPressed;
    public bool isTutorialDPressed;
    public bool isTutorialSPressed;
    public TutorialQuest activeTutorialQuest;
    public bool isQuestCompleted;
    public Quest mainQuest;
    public string questOwner;
    public Vector3 playerTransform;
    public SerializableDictionary<string, bool> flowersCollected;

    //Character Config
    public int headIndex, eyebrowIndex, facialHairIndex, headArmorIndex, torsoIndex, upperArmIndex, lowerArmIndex, handIndex, hipIndex, legIndex, hairIndex;
    public int gender;

    public GameData()
    {
        this.isTutorialCompleted = false;
        this.isTutorialWPressed = false;
        this.isTutorialAPressed = false;
        this.isTutorialDPressed = false;
        this.isTutorialSPressed = false;
        this.activeTutorialQuest = null;
        this.isQuestCompleted = false;
        this.questOwner = "";
        this.playerTransform = new Vector3(-50f, 0f , -9f);
        flowersCollected = new SerializableDictionary<string, bool>();
    }
}
