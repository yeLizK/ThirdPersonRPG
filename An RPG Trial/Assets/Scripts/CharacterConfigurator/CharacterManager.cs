using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterManager : MonoBehaviour, IDataPersistence
{
    private static CharacterManager _instance;
    public static CharacterManager Instance { get { return _instance; } }

    [HideInInspector]public int gender, skinColor, clotheIndex, clotheColourIndex, hairIndex, hairColourIndex,weaponIndex;
    [HideInInspector] public CharCustomiser charCustomiser;
    [SerializeField] private UI_Inventory uiInventory;

    [HideInInspector]public Inventory Inventory;

    [HideInInspector] public bool isCharHoldingSword;

    private int playerHealth= 100;


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
        charCustomiser = GetComponent<CharCustomiser>();
    }
    private void Start()
    {
        Inventory = new Inventory();
        uiInventory.RefreshInventoryItems();
        DataPersistenceManager.Instance.dataPersistenceObjects = DataPersistenceManager.Instance.FindAllDataPersistenceObjects();
        DataPersistenceManager.Instance.LoadGame();

        playerHealth = 100;
    }
    public void LoadData(GameData data)
    {
        //All Loads are handled in GameSpecifics.cs
    }

    public void SaveData(ref GameData data)
    {
        data.gender = this.gender;
        data.skinColor = this.skinColor;
        data.clotheIndex = this.clotheIndex;
        data.clotheColorIndex = this.clotheColourIndex;
        data.hairIndex = this.hairIndex;
        data.hairColourIndex = this.hairColourIndex;
        data.weaponIndex = this.weaponIndex;
        data.isCharHoldingSword = this.isCharHoldingSword;
        data.inventory = new List<Item>();
        for (int i = 0; i < Inventory.Instance.itemList.Count; i++)
        {
            data.inventory.Add(Inventory.Instance.itemList[i]);
        }
    }


    public void UpdateCharacterAppereance()
    {
        charCustomiser.RestoreToDefault();
        charCustomiser.UpdateCharacterWithValues(gender, skinColor, clotheIndex, clotheColourIndex, hairIndex, hairColourIndex);
    }

    public void TakeDamage(int damage) 
    {
        playerHealth -= damage;
        Debug.Log(playerHealth);
    }
}
