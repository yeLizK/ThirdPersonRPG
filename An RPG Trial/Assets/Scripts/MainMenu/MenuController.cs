using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using System.IO;


public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject menuButtonList;

    private List<AsyncOperation> scenesToLoad = new List<AsyncOperation>();
    private string fileName = "data.game";

    [SerializeField] private Button newGame, loadGame, settings, exit;

    private void Start()
    {
        string fullPath = Path.Combine(Application.persistentDataPath, fileName);
        if (!File.Exists(fullPath))
        {
            loadGame.interactable = false;
        }
        else loadGame.interactable = true;

    }

    public void StartNewGame()
    {
        HideMenuButtonList();
        scenesToLoad.Add(SceneManager.LoadSceneAsync("CharConfigurationScene"));
    }

    public void HideMenuButtonList()
    {
        menuButtonList.SetActive(false);
    }

    public void ExitToDesktop()
    {
        Application.Quit();
    }
}
