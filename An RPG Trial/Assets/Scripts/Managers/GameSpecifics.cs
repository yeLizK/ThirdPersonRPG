using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSpecifics : MonoBehaviour,IDataPersistence
{
    private static GameSpecifics _instance;
    public static GameSpecifics Instance { get { return _instance; } }

    [HideInInspector] public bool isNewGame;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this);
        }
        else
        {
            _instance = this;
        }
    }

    private void Start()
    {
        if (SceneManager.GetActiveScene().name.Equals("TutorialScene 1"))
        {
            DataPersistenceManager.Instance.LoadGame();
        }
    }

    public void LoadData(GameData data)
    {
        isNewGame = data.isNewGame;
        CharacterManager.Instance.gender = data.gender;
        CharacterManager.Instance.skinColor = data.skinColor;
        CharacterManager.Instance.clotheIndex = data.clotheIndex;
        CharacterManager.Instance.clotheColourIndex = data.clotheColorIndex;
        CharacterManager.Instance.hairIndex = data.hairIndex;
        CharacterManager.Instance.hairColourIndex = data.hairColourIndex;
        CharacterManager.Instance.weaponIndex = data.weaponIndex;
        CharacterManager.Instance.isCharHoldingSword = data.isCharHoldingSword;
        CharacterManager.Instance.UpdateCharacterAppereance();
        if (isNewGame)
        {
            data = new GameData();
        }
        else
        {
            if (CharacterManager.Instance.isCharHoldingSword)
            {
                CharacterManager.Instance.charCustomiser.EquipSword();
            }
            Item temp = null;
            for (int i = 0; i < data.inventory.Count; i++)
            {
                temp = data.inventory[i];
                Inventory.Instance.AddItem(temp);
            }
            UI_Inventory.Instance.RefreshInventoryItems();
        }
        
        CharacterMovement.Instance.transform.position = new Vector3(data.playerTransform.x, 0f, data.playerTransform.z);

        TutorialManager.Instance.isTutorialCompleted = data.isTutorialCompleted;
        TutorialManager.Instance.isWPressed = data.isTutorialWPressed;
        TutorialManager.Instance.isAPressed = data.isTutorialAPressed;
        TutorialManager.Instance.isDPressed = data.isTutorialDPressed;
        TutorialManager.Instance.isSPressed = data.isTutorialSPressed;
        TutorialManager.Instance.activeQuest = data.activeTutorialQuest;

        QuestManager.Instance.activeQuest = data.mainQuest;
        if (QuestManager.Instance.activeQuest == null || QuestManager.Instance.activeQuest.Name.Equals(""))
        {
            QuestManager.Instance.anyActiveQuest = false;
            TutorialManager.Instance.AssignTutorialQuest();
        }
        else QuestManager.Instance.anyActiveQuest = true;
        InGameUIManager.Instance.RefreshQuest();
        GameObject tmpQuestOwner = GameObject.Find(data.questOwner);
        if (tmpQuestOwner != null)
        {
            QuestManager.Instance.questOwner = tmpQuestOwner;
            tmpQuestOwner.GetComponent<NPCQuest>().AssignQuestToNPC(QuestManager.Instance.activeQuest);
        }
    }

    public void SaveData(ref GameData data)
    {
    }
}
