using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CinemachineCameraManager : MonoBehaviour
{
    private static CinemachineCameraManager _instance;
    public static CinemachineCameraManager Instance { get { return _instance; } }

    [SerializeField] private CinemachineVirtualCamera mainFPCamera, collectableFocusCamera, NPCFocusCam;

    private void Awake()
    {
        if (_instance!=null && _instance != this)
        {
            Destroy(_instance);
        }else
        {
            _instance = this;
        }
    }
    private void Start()
    {
        mainFPCamera.gameObject.SetActive(true);
        collectableFocusCamera.gameObject.SetActive(false);
    }


    public IEnumerator EndTutorial()
    {
        mainFPCamera.gameObject.SetActive(false);
        NPCFocusCam.gameObject.SetActive(true);
        yield return new WaitForSeconds(4.0f);
        mainFPCamera.gameObject.SetActive(true);
        NPCFocusCam.gameObject.SetActive(false);

    }

    public void EnterDialogueMode()
    {
        mainFPCamera.gameObject.SetActive(false);
        NPCFocusCam.gameObject.SetActive(true);
    }

    public void ExitDialogueMode()
    {
        mainFPCamera.gameObject.SetActive(true);
        NPCFocusCam.gameObject.SetActive(false);
    }
}
