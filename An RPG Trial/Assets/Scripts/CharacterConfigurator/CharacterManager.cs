using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterManager : MonoBehaviour
{
    private static CharacterManager _instance;
    public static CharacterManager Instance { get { return _instance; } }

    private string characterName = "";
    public int gender; // 0-male, 1-female

    public TMP_InputField nameField;

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

    private void Update()
    {
        characterName = nameField.text;
    }
}
