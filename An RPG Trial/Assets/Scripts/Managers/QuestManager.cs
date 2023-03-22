using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestManager : MonoBehaviour, IDataPersistence
{
    private static QuestManager _instance;
    public static QuestManager Instance { get { return _instance; } }

    [SerializeField]
    private QuestSO questList;

    private bool anyActiveQuest; //returns true if there is an active quest

    [HideInInspector]
    public Quest activeQuest;

    private GameObject questOwner;

    private void Awake()
    {
        if(_instance!=null && _instance!=this)
        {
            Destroy(_instance);
        }
        else
        {
            _instance = this;
        }
    }
  

    public void LoadData(GameData data)
    {
        this.activeQuest = data.mainQuest;
        if (activeQuest == null || activeQuest.Name.Equals("")) anyActiveQuest = false;
        else anyActiveQuest = true;
        InGameUIManager.Instance.RefreshQuest();
        GameObject temp = GameObject.Find(data.questOwner);
        if (temp == null)
        { return; }
        this.questOwner = temp;
        temp.GetComponent<NPCQuest>().AssignQuestToNPC(activeQuest);  
    }

    public void SaveData(ref GameData data)
    {
        data.mainQuest = this.activeQuest;
        data.isQuestCompleted = this.anyActiveQuest;
        if(questOwner != null) data.questOwner = this.questOwner.name;

    }


    public void AssignQuest()
    {
        questList = PlayerInteraction.Instance.interactedObject.GetComponent<NPCQuest>().questList;
        if (anyActiveQuest == false)
        {
            for(int i = 0; i <questList.quests.Count; i ++)
            {
                if (!questList.quests[i].Completed)
                {
                    questList.quests[i].isQuestActive = true;
                    activeQuest = questList.quests[i];
                    InGameUIManager.Instance.RefreshQuest();
                    PlayerInteraction.Instance.interactedObject.GetComponent<NPCQuest>().AssignQuestToNPC(activeQuest);
                    questOwner = PlayerInteraction.Instance.interactedObject;
                    return;
                }
            }
            
        }
    }

    public void EvaluateQuest()
    {
        if(activeQuest!=null)
        {
            if(activeQuest.EvaluateQuest(activeQuest.questObject))
            {
                activeQuest.Complete();
            }
        }
    }

    public void CompleteQuest()
    {
        activeQuest.isRewardTaken = true;
        activeQuest.isQuestAvailable = false;
        activeQuest.isQuestActive = false;
        activeQuest.Completed = true;
        activeQuest = null;
        DataPersistenceManager.Instance.SaveGame();
        if (activeQuest == null)
        {
            InGameUIManager.Instance.EmptyQuestList();
        }
        else InGameUIManager.Instance.RefreshQuest();
    }


}
