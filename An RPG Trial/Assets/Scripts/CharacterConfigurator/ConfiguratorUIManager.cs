using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class ConfiguratorUIManager : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerMoveHandler
{
    private static ConfiguratorUIManager _instance;
    public static ConfiguratorUIManager Instance { get { return _instance; } }


    [SerializeField] private GameObject ModularCharacter;

    private bool isCharRotating;
    private Vector3 mouseInitialPos;
    private Vector3 mouseOffset;
    private float mouseDragSensitivity;
    private Vector3 charRotation;

    [SerializeField] private TMP_Text HairText, ClotheText;

    private CharCustomiser charCustomiser;

    private void Awake()
    {
        if(_instance != null && _instance != this)
        {
            Destroy(_instance);
        }else
        {
            _instance = this;
        }
    }
    private void Start()
    {
        charCustomiser = CharCustomiser.Instance;
        isCharRotating = false;
        mouseDragSensitivity = 0.4f;
        
    }

    private void Update()
    {
        if (isCharRotating)
        {
            mouseOffset = (Input.mousePosition - mouseInitialPos);
            charRotation.y = (mouseOffset.x + mouseOffset.y) * 0.5f;
            ModularCharacter.transform.Rotate(charRotation);
            mouseInitialPos = Input.mousePosition;
        }
    }

    //Character Rotation
    public void OnPointerDown(PointerEventData eventData)
    {
        mouseInitialPos = Input.mousePosition;
        isCharRotating = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isCharRotating = false;
    }

    public void OnPointerMove(PointerEventData eventData)
    {
        if (isCharRotating)
        {
            mouseOffset = (Input.mousePosition - mouseInitialPos);
            charRotation.y = (mouseOffset.x + mouseOffset.y) * -mouseDragSensitivity;
            ModularCharacter.transform.Rotate(charRotation);
            mouseInitialPos = Input.mousePosition;
        }
    }

    //UI Elements Functionality - Gender Selection
    public void SelectMaleButton()
    {
        charCustomiser.SelectMale();
    }

    public void SelectFemaleButton()
    {
        charCustomiser.SelectFemale();
    }

    //UI Elements Functionality - Skin Colour Selection
    public void SelectBlackSkinColorButton()
    {
        charCustomiser.ChangeSkinColorToBlack();
    }

    public void SelectBrownSkinColorButton()
    {
        charCustomiser.ChangeSkinColorToBrown();
    }

    public void SelectWhiteSkinColorButton()
    {
        charCustomiser.ChangeSkinColorToWhite();
    }

    public void UpdateHairText(int selectionNumber)
    {
        HairText.text = "Hair  " + selectionNumber;
    }
    //UI Elements Functionality - Hair Selection
    public void ClickRightHairSelectionButton()
    {
        charCustomiser.ChangeHairRightSelection();
        int temp = charCustomiser.hairIndex+1;
        UpdateHairText(temp);
    }

    public void ClickLeftHairSelectionButton()
    {
        charCustomiser.ChangeHairLeftSelection();
        int temp = charCustomiser.hairIndex + 1;
        UpdateHairText(temp);

    }
    public void UpdateClotheText(int selectionNumber)
    {
        ClotheText.text = "Clothe " + selectionNumber;
    }
    public void ClickRightClotheSelectionButton()
    {
        charCustomiser.ChangeClothingRightSelection();
        int temp = charCustomiser.clotheIndex + 1;
        UpdateClotheText(temp);

    }
    public void ClickLeftClotheSelectionButton()
    {
        charCustomiser.ChangeClothingLeftSelection();
        int temp = charCustomiser.clotheIndex + 1;
        UpdateClotheText(temp);
    }


    //UI Elements Functionality - Clothe Colour Selection
    public void ClickClotheColorBlackButton()
    {
        charCustomiser.clotheColourIndex = 0;
        charCustomiser.UpdateCharacterAppereance();
    }
    public void ClickClotheColorBlueButton()
    {
        charCustomiser.clotheColourIndex = 1;
        charCustomiser.UpdateCharacterAppereance();
    }
    public void ClickClotheColorCyanButton()
    {
        charCustomiser.clotheColourIndex = 2;
        charCustomiser.UpdateCharacterAppereance();
    }
    public void ClickClotheColorPurpleButton()
    {
        charCustomiser.clotheColourIndex = 3;
        charCustomiser.UpdateCharacterAppereance();
    }
    public void ClickClotheColorWhiteButton()
    {
        charCustomiser.clotheColourIndex = 4;
        charCustomiser.UpdateCharacterAppereance();
    }
    //UI Elements Functionality - Hair Colour Selection
    public void ClickHairColorToBlackButton()
    {
        charCustomiser.ChangeHairColorToBlack();
    }
    public void ClickHairColorToYellowButton()
    {
        charCustomiser.ChangeHairColorToYellow();
    }
    public void ClickHairColorToBrownButton()
    {
        charCustomiser.ChangeHairColorToBrown();
    }
    public void ClickHairColorToCyanButton()
    {
        charCustomiser.ChangeHairColorToCyan();
    }
    public void ClickHairColorToPurpleButton()
    {
        charCustomiser.ChangeHairColorToPurple();
    }
    public void ClickHairColorToRedButton()
    {
        charCustomiser.ChangeHairColorToRed();
    }
    public void ClickHairColorToWhiteButton()
    {
        charCustomiser.ChangeHairColorToWhite();
    }
}
