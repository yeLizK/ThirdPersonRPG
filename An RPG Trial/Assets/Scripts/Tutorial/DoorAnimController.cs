using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimController : MonoBehaviour, ITutorialObserver
{
    [SerializeField]
    private TutorialSubject _tutorialManager;    
    private Animator doorAnim;
    private AudioSource gateOpeningSound;
    [SerializeField]
    private AudioSource gateClosingSound;

    private bool isDoorOpen;
    private void Start()
    {
        doorAnim = GetComponent<Animator>();
        gateOpeningSound = GetComponent<AudioSource>();
        doorAnim.ResetTrigger("OpenDoor");
        doorAnim.ResetTrigger("CloseDoor");

    }

    public void OpenDoor()
    {
        if(!isDoorOpen)
        {
            doorAnim.SetTrigger("OpenDoor");
            gateOpeningSound.Play();
            isDoorOpen = true;
        }

    }

    public void CloseDoor()
    {
        if(isDoorOpen)
        {
            doorAnim.SetTrigger("CloseDoor");
            gateClosingSound.Play();
            isDoorOpen = false;
        }


    }

    public void OnNotify(string actionName)
    {
        if(actionName.Equals("OpenGate"))
        {
            OpenDoor();
        }
        if (actionName.Equals("CloseGate"))
        {
            CloseDoor();
        }
    }

    private void OnEnable()
    {
        _tutorialManager.AddTutorialObserver(this);
    }

    private void OnDisable()
    {
        _tutorialManager.RemoveObserver(this);
    }
}
