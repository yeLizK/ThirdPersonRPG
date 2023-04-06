using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;
using UnityEngine.EventSystems;
using Cinemachine;
public class DialogueManager : MonoBehaviour
{
    private static DialogueManager _instance;
    public static DialogueManager Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null && _instance != this) Destroy(_instance);
        else _instance = this;
    }

    [Header("Dialog UI")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;

    [Header("Choices UI")]
    [SerializeField] private GameObject[] choices;
    private TextMeshProUGUI[] choicesText;

    [SerializeField] private TextAsset NotAnyMoreQuest, PlayerHasActiveQuest, QuestNotCompleted, GivingReward;
    private Story currentStory;

    [HideInInspector]public bool isDialoguePlaying { get; private set; }

    private CinemachineVirtualCamera NPCFocusCam;

    private void Start()
    {
        isDialoguePlaying = false;
        dialoguePanel.SetActive(false);

        choicesText = new TextMeshProUGUI[choices.Length];
        int index = 0;
        foreach(GameObject choice in choices)
        {
            choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }
    }

    public void EvaluateDialog(Transform hitObject)
    {
        if(hitObject.GetComponent<NPCQuest>().activeQuest !=null)
        {
            NPCFocusCam = hitObject.GetComponent<NPCQuest>().NPCFocusCam;
            if (hitObject.GetComponent<NPCQuest>().activeQuest.Completed && !hitObject.GetComponent<NPCQuest>().activeQuest.isRewardTaken)
            {
                EnterDialogueMode(GivingReward,hitObject.GetComponent<NPCQuest>().NPCFocusCam);
                hitObject.GetComponent<NPCQuest>().CompleteNPCQuest(hitObject.GetComponent<NPCQuest>().activeQuest);
                QuestManager.Instance.EvaluateQuest();
            }
            else if (hitObject.GetComponent<NPCQuest>().activeQuest == QuestManager.Instance.activeQuest)
            {
                EnterDialogueMode(QuestNotCompleted, hitObject.GetComponent<NPCQuest>().NPCFocusCam);
            }
            else if (hitObject.GetComponent<NPCQuest>().activeQuest != QuestManager.Instance.activeQuest)
            {
                EnterDialogueMode(PlayerHasActiveQuest, hitObject.GetComponent<NPCQuest>().NPCFocusCam);
            }
        }
    }

    public void EnterDialogueMode(TextAsset inkJSON, CinemachineVirtualCamera NPCFocusCam)
    {
        this.NPCFocusCam = NPCFocusCam;
        CinemachineCameraManager.Instance.EnterDialogueMode(NPCFocusCam);
        currentStory = new Story(inkJSON.text);
        isDialoguePlaying = true;
        dialoguePanel.SetActive(true);

        ContinueStory();
    }

    private IEnumerator ExitDialogueMode()
    {
        yield return new WaitForSeconds(0.1f);
        CinemachineCameraManager.Instance.ExitDialogueMode(NPCFocusCam);
        isDialoguePlaying = false;
        dialoguePanel.SetActive(false);
        NPCFocusCam = null;
        dialogueText.text = "";
    }

    public  void ContinueStory()
    {
        if(currentStory.currentChoices.Count==0)
        {
            if (currentStory.canContinue)
            {
                dialogueText.text = currentStory.Continue();
                DisplayChoices();
            }else
            StartCoroutine(ExitDialogueMode());
        }

    }

    private void DisplayChoices()
    {
        List<Choice> currentChoices = currentStory.currentChoices;
        if(currentChoices.Count> choices.Length)
        {
            Debug.Log("Too many choices!!");
        }

        int index = 0;
        foreach(Choice choice in currentChoices)
        {
            choices[index].gameObject.SetActive(true);
            choicesText[index].text = choice.text;
            index++;
        }
        for(int i=index;i<choices.Length; i++)
        {
            choices[i].gameObject.SetActive(false);
        }

        StartCoroutine(SelectFirstChoice());
    }
    
    private IEnumerator SelectFirstChoice()
    {
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(choices[0].gameObject);
    }
    
    public void MakeChoice(int choiceIndex)
    {
        currentStory.ChooseChoiceIndex(choiceIndex);
        ContinueStory();
    }
}
