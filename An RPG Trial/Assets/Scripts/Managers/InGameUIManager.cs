using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InGameUIManager : MonoBehaviour
{
    private static InGameUIManager _instance;
    public static InGameUIManager Instance { get { return _instance; } }
    [SerializeField]
    private TMP_Text interactionText,questName, questDescription;

    [SerializeField]
    private GameObject questHolder;

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
        CloseInteractionText();
    }

    public void RefreshQuest()
    {
        EmptyQuestList();
        if(QuestManager.Instance.activeQuest != null)
        {
            questName.text = QuestManager.Instance.activeQuest.Name;
            questDescription.text = QuestManager.Instance.activeQuest.Description;
            questHolder.GetComponent<Image>().enabled = true;
        }
        else if(TutorialManager.Instance.IsTutorialActive())
        {
            questName.text = TutorialManager.Instance.activeQuest.Name;
            questDescription.text = TutorialManager.Instance.activeQuest.Description;
            questHolder.GetComponent<Image>().enabled = true;
        }
    }

    public void EmptyQuestList()
    {
        questHolder.GetComponent<Image>().enabled = false;
        questName.text = "";
        questDescription.text = "";
    }

    public void OpenClickToTalkText()
    {
        interactionText.text = "[E] Click to Talk";
    }

    public void OpenClicktoCollectText()
    {
        interactionText.text = "[E] Click to Collect";

    }

    public void CloseInteractionText()
    {
        interactionText.text = "";
    }
}
