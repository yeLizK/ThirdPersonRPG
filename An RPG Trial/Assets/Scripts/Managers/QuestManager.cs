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

    private string questOwner;

    private void Awake()
    {
        if(_instance!=null &&_instance!=this)
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
        this.questOwner = data.questOwner;
        if (activeQuest == null || activeQuest.Name.Equals("")) anyActiveQuest = false;
        else anyActiveQuest = true;
        InGameUIManager.Instance.RefreshQuest();
        GameObject temp = GameObject.Find(questOwner);
        if (temp == null)
        { return; }
        temp.GetComponent<NPCDialog>().AssignQuestToNPC(activeQuest);
        
    }

    public void SaveData(ref GameData data)
    {
        data.mainQuest = this.activeQuest;
        data.isQuestCompleted = this.anyActiveQuest;
        data.questOwner = this.questOwner;
    }


    public void AssignQuest()
    {
        if (anyActiveQuest == false)
        {
            for(int i = 0; i <questList.quests.Count; i ++)
            {
                if (!questList.quests[i].Completed)
                {
                    questList.quests[i].isQuestActive = true;
                    activeQuest = questList.quests[i];
                    InGameUIManager.Instance.RefreshQuest();
                    PlayerInteraction.Instance.interactedObject.GetComponent<NPCDialog>().AssignQuestToNPC(activeQuest);
                    questOwner = PlayerInteraction.Instance.interactedObject.name.ToString();
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
                CompleteQuest();
                PlayerInteraction.Instance.interactedObject.GetComponent<NPCDialog>().EvaluateQuest(activeQuest);
            }
        }
    }

    public void CompleteQuest()
    {
        activeQuest.Complete();
        activeQuest = null;
        if (activeQuest == null)
        {
            InGameUIManager.Instance.EmptyQuestList();
        }
        else InGameUIManager.Instance.RefreshQuest();
    }


}
