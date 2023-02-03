using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    private static TutorialManager _instance;
    public  static TutorialManager Instance { get { return _instance; } }

    private bool isWPressed, isAPressed, isSPressed, isDPressed, isCameraMoved;

    private bool isTutorialCompleted;
    private InputManager inputManager;

    public TutorialQuestSO tutorialSO;
    [HideInInspector]
    public TutorialQuest activeQuest;
    private void Awake()
    {
        if(_instance !=null && _instance != this)
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
        inputManager = InputManager.Instance;
        isTutorialCompleted = false;
        activeQuest = null;
        isWPressed = false;
        isAPressed = false;
        isDPressed = false;
        isSPressed = false;
        isCameraMoved = false;

        if(isTutorialActive()&&activeQuest==null)
        {
            AssignTutorialQuest();
        }

    }

    private void Update()
    {
        if(isTutorialActive())
        {
            if (isAPressed || isDPressed || isWPressed || isSPressed)
            {
                inputManager.UnboundKeyboardEvent();
            }


            if (isCameraMoved)
            {
                inputManager.UnboundCameraEvent();
            }


            if(isAPressed&&isSPressed&&isWPressed&&isDPressed&&isCameraMoved)
            {
                isTutorialCompleted = true;
            }
        }

    }
    private void AssignTutorialQuest()
    {
        if (activeQuest != null)
        {
            activeQuest.isQuestActive = false;
            activeQuest.Completed = true;
        }
        for (int i = 0; i < tutorialSO.tutorialQuests.Count; i++)
        {
            if (!tutorialSO.tutorialQuests[i].Completed)
            {
                tutorialSO.tutorialQuests[i].isQuestActive = true;
                activeQuest = tutorialSO.tutorialQuests[i];
                InGameUIManager.Instance.RefreshQuest();
                return;
            }
        }
        InGameUIManager.Instance.EmptyQuestList();
        activeQuest = null;
        isTutorialCompleted = true;
        QuestManager.Instance.AssignGatheringQuest();

    }

    public void MoveCamera()
    {
        if (activeQuest.key.Equals("Camera"))
        {
            isCameraMoved = true;
            AssignTutorialQuest();

        }

    }
    public void PressW()
    {
        if(activeQuest.key.Equals("W"))
        {
            isWPressed = true;
            AssignTutorialQuest();
        }

    }
    public void PressA()
    {
        if(activeQuest.key.Equals("A"))
        {
            isAPressed = true;
            AssignTutorialQuest();

        }

    }
    public void PressS()
    {
        if (activeQuest.key.Equals("S"))
        {
            isDPressed = true;
            AssignTutorialQuest();

        }
    }
    public void PressD()
    {
        if (activeQuest.key.Equals("D"))
        {
            isSPressed = true;
            AssignTutorialQuest();

        }
    }

    public bool isTutorialActive()
    {
        if (isTutorialCompleted)
        { return false; }
        else return true;
    }

}
