using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterManager : MonoBehaviour, IDataPersistence
{
    private static CharacterManager _instance;
    public static CharacterManager Instance { get { return _instance; } }

    [HideInInspector]public int gender, skinColor, clotheIndex, clotheColourIndex, hairIndex, hairColourIndex;
    [SerializeField] private CharCustomiser charCustomiser;
    [SerializeField] private UI_Inventory uiInventory;

    private Inventory inventory;


    private void Awake()
    {
        if (_instance != null && _instance!= this )
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }

    }
    private void Start()
    {
        inventory = new Inventory();
        uiInventory.RefreshInventoryItems();
        DataPersistenceManager.Instance.dataPersistenceObjects = DataPersistenceManager.Instance.FindAllDataPersistenceObjects();
        DataPersistenceManager.Instance.LoadGame();
    }
    public void LoadData(GameData data)
    {
        this.gender = data.gender;
        this.skinColor = data.skinColor;
        this.clotheIndex = data.clotheIndex;
        this.clotheColourIndex = data.clotheColorIndex;
        this.hairIndex = data.hairIndex;
        this.hairColourIndex = data.hairColourIndex;
        UpdateCharacterAppereance();

    }

    public void SaveData(ref GameData data)
    {
        data.gender = this.gender;
        data.skinColor = this.skinColor;
        data.clotheIndex = this.clotheIndex;
        data.clotheColorIndex = this.clotheColourIndex;
        data.hairIndex = this.hairIndex;
        data.hairColourIndex = this.hairColourIndex;
    }


    public void UpdateCharacterAppereance()
    {
        charCustomiser.RestoreToDefault();
        charCustomiser.UpdateCharacterWithValues(gender, skinColor, clotheIndex, clotheColourIndex, hairIndex, hairColourIndex);
    }

}
