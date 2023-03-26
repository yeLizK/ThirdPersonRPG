using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CinemachineCameraManager : MonoBehaviour
{
    private static CinemachineCameraManager _instance;
    public static CinemachineCameraManager Instance { get { return _instance; } }

    [SerializeField] private CinemachineVirtualCamera mainFPCamera, NPCFocusCam;

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

    }
    public IEnumerator EndTutorial()
    {
        mainFPCamera.gameObject.SetActive(false);
        NPCFocusCam.gameObject.SetActive(true);
        yield return new WaitForSeconds(1.0f);
        NPCFocusCam.gameObject.SetActive(false);
        mainFPCamera.gameObject.SetActive(true);
    }

    public void EnterDialogueMode()
    {
        mainFPCamera.gameObject.SetActive(false);
        NPCFocusCam.gameObject.SetActive(true);
    }

    public void ExitDialogueMode()
    {
        NPCFocusCam.gameObject.SetActive(false);
        mainFPCamera.gameObject.SetActive(true);
    }
}
