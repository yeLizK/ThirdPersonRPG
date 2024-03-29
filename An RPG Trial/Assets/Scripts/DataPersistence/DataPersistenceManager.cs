using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class DataPersistenceManager : MonoBehaviour
{
    [Header("File Storage Config")]
    [SerializeField] private string fileName;
    private GameData gameData;
    [HideInInspector]public List<IDataPersistence> dataPersistenceObjects;

    private FileDataHandler dataHandler;
    public static DataPersistenceManager Instance { get; private set; }

    private void Awake()
    {
        if(Instance != null)
        {
            Debug.LogError("Found more than one Data Persistence Manager in the scene");
        }
        Instance = this;
    }

    private void Start()
    {
        this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
        this.dataPersistenceObjects = FindAllDataPersistenceObjects();
        LoadGame();
        DontDestroyOnLoad(this);
    }

    public List<IDataPersistence> FindAllDataPersistenceObjects()
    {
        IEnumerable<IDataPersistence> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistence>();

        return new List<IDataPersistence>(dataPersistenceObjects);
    }

    public void NewGame()
    {
        this.gameData = new GameData();
    }

    public void LoadGame()
    {
        this.gameData = dataHandler.Load();
        if(this.gameData == null)
        {
            Debug.Log("No data was found. Initializing data defaults.");
            NewGame();
        }

        foreach(IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.LoadData(gameData);
        }
    }

    public void SaveGame()
    {
        foreach(IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.SaveData(ref gameData);
        }
        dataHandler.Save(gameData);
    }
    private void OnApplicationQuit()
    {
        SaveGame();
    }

    public void DeleteAllDataPersistenceObject()
    {
        foreach(IDataPersistence item in dataPersistenceObjects)
        {
            dataPersistenceObjects.Remove(item);
        }
    }
}
