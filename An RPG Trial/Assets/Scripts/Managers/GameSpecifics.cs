using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSpecifics : MonoBehaviour,IDataPersistence
{
    private static GameSpecifics _instance;
    public static GameSpecifics Instance { get { return _instance; } }

    [HideInInspector] public bool isNewGame;

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

    private void Start()
    {
        if (SceneManager.GetActiveScene().name.Equals("TutorialScene 1"))
        {
            if (isNewGame == true)
            {
                CharacterMovement.Instance.ReassingPlayerTransform();
            }
            else
            {
                DataPersistenceManager.Instance.LoadGame();
            }
        }
    }

    public void LoadData(GameData data)
    {
        isNewGame = data.isNewGame;
    }

    public void SaveData(ref GameData data)
    {
        throw new System.NotImplementedException();
    }
}
