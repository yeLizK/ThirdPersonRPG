using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterManager : MonoBehaviour, IDataPersistence
{
    private static CharacterManager _instance;
    public static CharacterManager Instance { get { return _instance; } }

    [HideInInspector]public int gender, skinColor, clotheIndex, clotheColorIndex, hairIndex, hairColourIndex;

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
        DataPersistenceManager.Instance.LoadGame();
    }
    public void LoadData(GameData data)
    {
        this.gender = data.gender;
        this.skinColor = data.skinColor;
        this.clotheIndex = data.clotheIndex;
        this.clotheColorIndex = data.clotheColorIndex;
        this.hairIndex = data.hairIndex;
        this.hairColourIndex = data.hairColourIndex;
    }

    public void SaveData(ref GameData data)
    {
        data.gender = this.gender;
        data.skinColor = this.skinColor;
        data.clotheIndex = this.clotheIndex;
        data.clotheColorIndex = this.clotheColorIndex;
        data.hairIndex = this.hairIndex;
        data.hairColourIndex = this.hairColourIndex;
    }


}
