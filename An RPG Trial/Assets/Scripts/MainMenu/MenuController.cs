using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using System.IO;

public class MenuController : MonoBehaviour, IDataPersistence
{
    private static MenuController _instance;
    public static MenuController Instance { get { return _instance; } }

    [SerializeField] private GameObject mainMenuPanel, characterConfiguratorPanel, mainMenuConfirmationPanel;

    private List<AsyncOperation> scenesToLoad = new List<AsyncOperation>();
    private string fileName = "data.game";

    [SerializeField] private Button newGame, loadGame, settings, exit;

    private CharCustomiser charCustomiser;

    private bool isNewGame;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(_instance);
        }
        else _instance = this;

    }
    private void Start()
    {
        charCustomiser = FindObjectOfType<CharCustomiser>();

        string fullPath = Path.Combine(Application.persistentDataPath, fileName);
        if (!File.Exists(fullPath))
        {
            loadGame.interactable = false;
        }
        else loadGame.interactable = true;

        characterConfiguratorPanel.SetActive(false);

    }

    public void OpenCharacterConfigurator()
    {
        DataPersistenceManager.Instance.NewGame();
        HideMainMenu();
        characterConfiguratorPanel.SetActive(true);
        charCustomiser.RestoreToDefault();
    }

    public void StartNewGame()
    {
        DataPersistenceManager.Instance.NewGame();
        isNewGame = true;
        DataPersistenceManager.Instance.SaveGame();
        SceneManager.LoadScene("TutorialScene 1");
    }

    public void LoadGame()
    {
        isNewGame = false;
        DataPersistenceManager.Instance.SaveGame();
        SceneManager.LoadScene("TutorialScene 1");
    }

    public void HideMainMenu()
    {
        mainMenuPanel.SetActive(false);
    }
    public void ConfirmReturnToMainMenu()
    {
        mainMenuConfirmationPanel.SetActive(true);
    }
    public void CloseMainMenuConfirmationPanel()
    {
        mainMenuConfirmationPanel.SetActive(false);

    }

    public void ReturnToMainMenu()
    {
        mainMenuPanel.SetActive(true);
        characterConfiguratorPanel.SetActive(false);
        mainMenuConfirmationPanel.SetActive(false);
    }

    public void ExitToDesktop()
    {
        Application.Quit();
    }

    public void LoadData(GameData data)
    {
    }

    public void SaveData(ref GameData data)
    {
        data.isNewGame = isNewGame;
    }
}
