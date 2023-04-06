using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class NPCDialogue : MonoBehaviour
{
    [SerializeField] private List<Dialogue> dialogueList;
    [SerializeField] private CinemachineVirtualCamera NPCFocusCam;
    private int dialogueListIndex;
    private Dialogue activeDialogue;


    // Start is called before the first frame update
    void Start()
    {
        dialogueListIndex = 0;
    }

    private void GetANewDialogue()
    {
        activeDialogue = dialogueList[dialogueListIndex];
        dialogueListIndex++;
    }
}
