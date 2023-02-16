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
    private TMP_Text interactionText;

    [SerializeField]
    private TMP_Text questName, questDescription;

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
    private void Update()
    {
        if(CameraRaycast.Instance.isHitCollectable)
        {
            interactionText.text = "[E] Click to Collect";
        }
        else if(CameraRaycast.Instance.isHitNPC)
        {
            interactionText.text = "[E] Click to Talk";
        }
        else
        {
            interactionText.text = "";
        }

    }

    public void RefreshQuest()
    {
        if(TutorialManager.Instance.IsTutorialActive())
        {
            questName.text = TutorialManager.Instance.activeQuest.Name;
            questDescription.text = TutorialManager.Instance.activeQuest.Description;
        }
        else
        {
            questName.text = QuestManager.Instance.activeQuest.Name;
            questDescription.text = QuestManager.Instance.activeQuest.Description;
        }
    }

    public void EmptyQuestList()
    {
        questName.text = "";
        questDescription.text = "";
    }
}
