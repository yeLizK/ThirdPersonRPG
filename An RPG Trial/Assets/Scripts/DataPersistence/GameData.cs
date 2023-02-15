using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public bool isTutorialCompleted;
    public bool isTutorialCameraMoved;
    public bool isTutorialWPressed;
    public bool isTutorialAPressed;
    public bool isTutorialDPressed;
    public bool isTutorialSPressed;
    public TutorialQuest activeTutorialQuest;
    public Quest activeQuest;
    public Vector3 playerTransform;
    public SerializableDictionary<string, bool> flowersCollected;

    public GameData()
    {
        this.isTutorialCompleted = false;
        this.isTutorialCameraMoved = false;
        this.isTutorialWPressed = false;
        this.isTutorialAPressed = false;
        this.isTutorialDPressed = false;
        this.isTutorialSPressed = false;
        this.activeTutorialQuest = null;
        this.activeQuest = null;
        this.playerTransform = new Vector3(-50f, 0f , -9f);
        flowersCollected = new SerializableDictionary<string, bool>();
    }
}
