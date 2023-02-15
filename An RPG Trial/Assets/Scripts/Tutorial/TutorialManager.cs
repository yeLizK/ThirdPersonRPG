using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : TutorialSubject , IDataPersistence
{
    private static TutorialManager _instance;
    public  static TutorialManager Instance { get { return _instance; } }

    private bool isWPressed, isAPressed, isSPressed, isDPressed, isCameraMoved;

    private InputManager inputManager;

    public TutorialQuestSO tutorialSO;
    [HideInInspector]
    public TutorialQuest activeQuest;
    [HideInInspector]
    public bool isTutorialCompleted;
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

        if (IsTutorialActive())
        {
            AssignTutorialQuest();
        }
        
    }

    public void LoadData(GameData data)
    {
        this.isTutorialCompleted = data.isTutorialCompleted;
        this.isCameraMoved = data.isTutorialCameraMoved;
        this.isWPressed = data.isTutorialWPressed;
        this.isAPressed = data.isTutorialAPressed;
        this.isDPressed = data.isTutorialDPressed;
        this.isSPressed = data.isTutorialSPressed;
        this.activeQuest = data.activeTutorialQuest;
    }
    public void SaveData(ref GameData data)
    {
        data.isTutorialCompleted = this.isTutorialCompleted;
        data.isTutorialCameraMoved = this.isCameraMoved;
        data.isTutorialWPressed = this.isWPressed;
        data.isTutorialAPressed = this.isAPressed;
        data.isTutorialDPressed = this.isDPressed;
        data.isTutorialSPressed = this.isSPressed;
        data.activeTutorialQuest = this.activeQuest;
    }

    private void Update()
    {
        if(!isTutorialCompleted)
        {
            if (isCameraMoved)
            {
                inputManager.UnbindCameraEvent();
            }

            if (isAPressed && isSPressed && isWPressed && isDPressed && isCameraMoved)
            {
                isTutorialCompleted = true;
                inputManager.UnbindKeyboardEvent();
            }

        }

    }
    private void AssignTutorialQuest()
    {
        if(IsTutorialActive())
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
            EndTutorial();
        }

    }

    private void EndTutorial()
    {
        isTutorialCompleted = true;
        QuestManager.Instance.AssignQuest();
        NotifyTutorialObservers("OpenGate");
    }

    public void CloseTutorialGate()
    {
        NotifyTutorialObservers("CloseGate");
        StartCoroutine(CinemachineCameraManager.Instance.EndTutorial());

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
            isSPressed = true;
            AssignTutorialQuest();

        }
    }
    public void PressD()
    {
        if (activeQuest.key.Equals("D"))
        {
            isDPressed = true;
            AssignTutorialQuest();
        }
    }

    public bool IsTutorialActive()
    {
        if (isTutorialCompleted)
        { return false; }
        else return true;
    }


}
