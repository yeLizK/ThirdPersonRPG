using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public bool isNewGame;

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
    public SerializableDictionary<string, int> inventory;

    //Character Config
    public int gender, skinColor, clotheIndex, clotheColorIndex, hairIndex, hairColourIndex, weaponIndex;
    public bool isCharHoldingSword;
    public bool isCharHoldingShield;

    public GameData()
    {
        isNewGame = true;
        this.isTutorialCompleted = false;
        this.isTutorialWPressed = false;
        this.isTutorialAPressed = false;
        this.isTutorialDPressed = false;
        this.isTutorialSPressed = false;
        this.activeTutorialQuest = null;
        this.isQuestCompleted = false;
        mainQuest = null;
        this.questOwner = "";
        this.playerTransform = new Vector3(0f, 0f , 0f);
        inventory = new SerializableDictionary<string, int>();

        gender = 0;
        skinColor = 0;
        clotheIndex = 0;
        clotheColorIndex = 0;
        hairIndex = 0;
        hairColourIndex=0;
        weaponIndex = 0;
        isCharHoldingSword = false;
        isCharHoldingShield = false;
    }
}
