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

    private Inventory inventory;

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

    }
    private void Start()
    {
        inventory = new Inventory();
        uiInventory.RefreshInventoryItems();
        charCustomiser = GetComponent<CharCustomiser>();
        DataPersistenceManager.Instance.dataPersistenceObjects = DataPersistenceManager.Instance.FindAllDataPersistenceObjects();
        DataPersistenceManager.Instance.LoadGame();

        playerHealth = 100;
    }
    public void LoadData(GameData data)
    {
        this.gender = data.gender;
        this.skinColor = data.skinColor;
        this.clotheIndex = data.clotheIndex;
        this.clotheColourIndex = data.clotheColorIndex;
        this.hairIndex = data.hairIndex;
        this.hairColourIndex = data.hairColourIndex;
        this.weaponIndex = data.weaponIndex;
        this.isCharHoldingSword = data.isCharHoldingSword;
        UpdateCharacterAppereance();
        if(isCharHoldingSword)
        {
            charCustomiser.EquipSword();
        }
        Item temp =null;
        for (int i = 0; i < data.inventory.Count; i++)
        {
            temp = data.inventory[i];
            Inventory.Instance.AddItem(temp);
        }
        UI_Inventory.Instance.RefreshInventoryItems();

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
        data.inventory =new List<Item>();
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
