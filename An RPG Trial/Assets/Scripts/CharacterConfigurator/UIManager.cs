using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class UIManager : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerMoveHandler
{
    public GameObject ModularChar;
    public GameObject HeadSelectionPanel;
    public GameObject UpperBodySelectionPanel;
    public GameObject LowerBodySelectionPanel;
    public Animator CameraAnim;

    public GameObject maleChar;
    public GameObject femaleChar;
    public GameObject FacialHairPanel;

    private Vector3 mouseInitialPos;
    private Vector3 mouseOffset;
    private Vector3 charRotation;
    private bool isCharRotating;
    private float mouseDragSensitivity;

    public TMP_Text HeadText;
    public TMP_Text EyebrowText;
    public TMP_Text FacialHairText;
    public TMP_Text HeadArmorText;
    public TMP_Text TorsoText;
    public TMP_Text UpperArmText;
    public TMP_Text LowerArmText;
    public TMP_Text HandText;
    public TMP_Text HipText;
    public TMP_Text LegText;
    public TMP_Text HairText;

    private bool isHeadSelected, isUpperBodySelected, isLowerBodySelected;

    private void Start()
    {
        charRotation = Vector3.zero;
        mouseDragSensitivity = 0.4f;

        ResetChar();
        SetCameraToDefaultPos();
        isHeadSelected = false;
        isUpperBodySelected = false;
        isLowerBodySelected = false;

    }
    private void Update()
    {
        if(isCharRotating)
        {
            mouseOffset = (Input.mousePosition - mouseInitialPos);
            charRotation.y = (mouseOffset.x + mouseOffset.y) * 0.5f;
            ModularChar.transform.Rotate(charRotation);
            mouseInitialPos = Input.mousePosition;
        }
    }

    public void SelectHeadConfiguration() 
    {
        if (!isHeadSelected)
        {
            CameraAnim.SetTrigger("ZoomHead");
            HeadSelectionPanel.SetActive(true);
            UpperBodySelectionPanel.SetActive(false);
            LowerBodySelectionPanel.SetActive(false);
            isHeadSelected = true;
            isUpperBodySelected = false;
            isLowerBodySelected = false;
        }
        else SetCameraToDefaultPos();

    }
    public void SelectUpperBodyConfiguration()
    {
        CameraAnim.SetTrigger("ZoomBody");
        if(!isUpperBodySelected)
        {
            HeadSelectionPanel.SetActive(false);
            UpperBodySelectionPanel.SetActive(true);
            LowerBodySelectionPanel.SetActive(false);
            isHeadSelected = false;
            isUpperBodySelected = true;
            isLowerBodySelected = false;
        }
        else SetCameraToDefaultPos();


    }

    public void SelectLowerBodyConfiguration()
    {
        CameraAnim.SetTrigger("ZoomHips");
        if(!isLowerBodySelected)
        {
            HeadSelectionPanel.SetActive(false);
            UpperBodySelectionPanel.SetActive(false);
            LowerBodySelectionPanel.SetActive(true);
            isHeadSelected = false;
            isUpperBodySelected = false;
            isLowerBodySelected = true;
        }
        else SetCameraToDefaultPos();

    }

    public void SetCameraToDefaultPos()
    {
        CameraAnim.SetTrigger("ZoomOut");
        HeadSelectionPanel.SetActive(false);
        UpperBodySelectionPanel.SetActive(false);
        LowerBodySelectionPanel.SetActive(false);
        isHeadSelected = false;
        isUpperBodySelected = false;
        isLowerBodySelected = false;
    }

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
        if(isCharRotating)
        {
            mouseOffset = (Input.mousePosition - mouseInitialPos);
            charRotation.y = (mouseOffset.x + mouseOffset.y) * -mouseDragSensitivity;
            ModularChar.transform.Rotate(charRotation);
            mouseInitialPos = Input.mousePosition;
        }
    }

    public void SelectMale()
    {
        FemaleKnightCustomiser.Instance.enabled = false;
        MaleKnightCustomiser.Instance.enabled = true;
        CharacterManager.Instance.gender = 0;
        FacialHairPanel.SetActive(true);
        maleChar.SetActive(true);
        femaleChar.SetActive(false);
        FemaleKnightCustomiser.Instance.ChangeGenderFromFemaleToMale();
    }

    public void SelectFemale()
    {
        FemaleKnightCustomiser.Instance.enabled = true;
        MaleKnightCustomiser.Instance.enabled = false;
        CharacterManager.Instance.gender = 1;
        FacialHairPanel.SetActive(false);
        maleChar.SetActive(false);
        femaleChar.SetActive(true);
        MaleKnightCustomiser.Instance.ChangeGenderFromMaleToFemale();
    }

    public void HeadRight()
    {
        if (CharacterManager.Instance.gender == 0)
        {
            MaleKnightCustomiser.Instance.HeadSelectionRight();
            HeadText.text = "Head " + (MaleKnightCustomiser.Instance.headIndex + 1);
        }
        else if (CharacterManager.Instance.gender == 1){
            FemaleKnightCustomiser.Instance.HeadSelectionRight();
            HeadText.text = "Head " + (FemaleKnightCustomiser.Instance.headIndex + 1);
        }
    }

    public void HeadLeft()
    {
        if (CharacterManager.Instance.gender == 0)
        {
            MaleKnightCustomiser.Instance.HeadSelectionLeft();
            HeadText.text = "Head " + (MaleKnightCustomiser.Instance.headIndex + 1);
        }
        else if (CharacterManager.Instance.gender == 1)
        {
            FemaleKnightCustomiser.Instance.HeadSelectionLeft();
            HeadText.text = "Head " + (FemaleKnightCustomiser.Instance.headIndex + 1);
        }
    }

    public void EyebrowRight()
    {
        if (CharacterManager.Instance.gender == 0)
        {
            MaleKnightCustomiser.Instance.EyebrowSelectionRight();
            EyebrowText.text = "Eyebrows " + (MaleKnightCustomiser.Instance.eyebrowIndex + 1);
        }
        else if (CharacterManager.Instance.gender == 1)
        {
            FemaleKnightCustomiser.Instance.EyebrowSelectionRight();
            EyebrowText.text = "Eyebrows " + (FemaleKnightCustomiser.Instance.eyebrowIndex + 1);
        }
    }

    public void EyebrowLeft()
    {
        if (CharacterManager.Instance.gender == 0)
        {
            MaleKnightCustomiser.Instance.EyebrowSelectionLeft();
            EyebrowText.text = "Eyebrows " + (MaleKnightCustomiser.Instance.eyebrowIndex + 1);
        }
        else if (CharacterManager.Instance.gender == 1)
        {
            FemaleKnightCustomiser.Instance.EyebrowSelectionLeft();
            EyebrowText.text = "Eyebrows " + (FemaleKnightCustomiser.Instance.eyebrowIndex + 1);
        }
    }

    public void FacialHairRight()
    {
        MaleKnightCustomiser.Instance.FacialHairSelectionRight();
        FacialHairText.text = "Facial Hair " + (MaleKnightCustomiser.Instance.facialHairIndex + 1);
    }
    public void FacialHairLeft()
    {
        MaleKnightCustomiser.Instance.FacialHairSelectionLeft();
        FacialHairText.text = "Facial Hair " + (MaleKnightCustomiser.Instance.facialHairIndex + 1);
    }

    public void HeadArmorRight()
    {
        if (CharacterManager.Instance.gender == 0)
        {
            MaleKnightCustomiser.Instance.HeadArmorSelectionRight();
            HeadArmorText.text = "Head Armor " + (MaleKnightCustomiser.Instance.headArmorIndex + 1);
        }
        else if (CharacterManager.Instance.gender == 1)
        {
            FemaleKnightCustomiser.Instance.HeadArmorSelectionRight();
            HeadArmorText.text = "Head Armor " + (FemaleKnightCustomiser.Instance.headArmorIndex + 1);
        }
    }

    public void HeadArmorLeft()
    {
        if (CharacterManager.Instance.gender == 0)
        {
            MaleKnightCustomiser.Instance.HeadArmorSelectionLeft();
            HeadArmorText.text = "Head Armor " + (MaleKnightCustomiser.Instance.headArmorIndex + 1);
        }
        else if (CharacterManager.Instance.gender == 1)
        {
            FemaleKnightCustomiser.Instance.HeadArmorSelectionLeft();
            HeadArmorText.text = "Head Armor " + (FemaleKnightCustomiser.Instance.headArmorIndex + 1);

        }
    }
    public void TorsoRight()
    {
        if (CharacterManager.Instance.gender == 0)
        {
            MaleKnightCustomiser.Instance.TorsoSelectionRight();
            TorsoText.text = "Torso " + (MaleKnightCustomiser.Instance.torsoIndex + 1);
        }
        else if (CharacterManager.Instance.gender == 1)
        {
            FemaleKnightCustomiser.Instance.TorsoSelectionRight();
            TorsoText.text = "Torso " + (FemaleKnightCustomiser.Instance.torsoIndex + 1);
        }
    }

    public void TorsoLeft()
    {
        if (CharacterManager.Instance.gender == 0)
        {
            MaleKnightCustomiser.Instance.TorsoSelectionLeft();
            TorsoText.text = "Torso " + (MaleKnightCustomiser.Instance.torsoIndex + 1);
        }
        else if (CharacterManager.Instance.gender == 1)
        {
            FemaleKnightCustomiser.Instance.TorsoSelectionLeft();
            TorsoText.text = "Torso " + (FemaleKnightCustomiser.Instance.torsoIndex + 1);
        }
    }

    public void UpperArmRight()
    {
        if (CharacterManager.Instance.gender == 0)
        {
            MaleKnightCustomiser.Instance.UpperArmSelectionRight();
            UpperArmText.text = "Upper Arm " + (MaleKnightCustomiser.Instance.upperArmIndex + 1);
        }
        else if (CharacterManager.Instance.gender == 1)
        {
            FemaleKnightCustomiser.Instance.UpperArmSelectionRight();
            UpperArmText.text = "Upper Arm " + (FemaleKnightCustomiser.Instance.upperArmIndex + 1);
        }
    }

    public void UpperArmLeft()
    {
        if (CharacterManager.Instance.gender == 0)
        {
            MaleKnightCustomiser.Instance.UpperArmSelectionLeft();
            UpperArmText.text = "Upper Arm " + (MaleKnightCustomiser.Instance.upperArmIndex + 1);
        }
        else if (CharacterManager.Instance.gender == 1)
        {
            FemaleKnightCustomiser.Instance.UpperArmSelectionLeft();
            UpperArmText.text = "Upper Arm " + (FemaleKnightCustomiser.Instance.upperArmIndex + 1);
        }
    }

    public void LowerArmRight()
    {
        if (CharacterManager.Instance.gender == 0)
        {
            MaleKnightCustomiser.Instance.LowerArmSelectionRight();
            LowerArmText.text = "Lower Arm " + (MaleKnightCustomiser.Instance.lowerArmIndex + 1);
        }
        else if (CharacterManager.Instance.gender == 1)
        {
            FemaleKnightCustomiser.Instance.LowerArmSelectionRight();
            LowerArmText.text = "Lower Arm " + (FemaleKnightCustomiser.Instance.lowerArmIndex + 1);
        }
    }

    public void LowerArmLeft()
    {
        if (CharacterManager.Instance.gender == 0)
        {
            MaleKnightCustomiser.Instance.LowerArmSelectionLeft();
            LowerArmText.text = "Lower Arm " + (MaleKnightCustomiser.Instance.lowerArmIndex + 1);
        }
        else if (CharacterManager.Instance.gender == 1)
        {
            FemaleKnightCustomiser.Instance.LowerArmSelectionLeft();
            LowerArmText.text = "Lower Arm " + (FemaleKnightCustomiser.Instance.lowerArmIndex + 1);
        }
    }

    public void HandRight()
    {
        if (CharacterManager.Instance.gender == 0)
        {
            MaleKnightCustomiser.Instance.HandSelectionRight();
            HandText.text = "Hand " + (MaleKnightCustomiser.Instance.handIndex + 1);
        }
        else if (CharacterManager.Instance.gender == 1)
        {
            FemaleKnightCustomiser.Instance.HandSelectionRight();
            HandText.text = "Hand " + (FemaleKnightCustomiser.Instance.handIndex + 1);
        }
    }

    public void HandLeft()
    {
        if (CharacterManager.Instance.gender == 0)
        {
            MaleKnightCustomiser.Instance.HandSelectionLeft();
            HandText.text = "Hand " + (MaleKnightCustomiser.Instance.handIndex + 1);
        }
        else if (CharacterManager.Instance.gender == 1)
        {
            FemaleKnightCustomiser.Instance.HandSelectionLeft();
            HandText.text = "Hand " + (FemaleKnightCustomiser.Instance.handIndex + 1);
        }
    }
    public void HipRight()
    {
        if (CharacterManager.Instance.gender == 0)
        {
            MaleKnightCustomiser.Instance.HipSelectionRight();
            HipText.text = "Hip " + (MaleKnightCustomiser.Instance.hipIndex + 1);
        }
        else if (CharacterManager.Instance.gender == 1)
        {
            FemaleKnightCustomiser.Instance.HipSelectionRight();
            HipText.text = "Hip " + (FemaleKnightCustomiser.Instance.hipIndex + 1);
        }
    }

    public void HipLeft()
    {
        if (CharacterManager.Instance.gender == 0)
        {
            MaleKnightCustomiser.Instance.HipSelectionLeft();
            HipText.text = "Hip " + (MaleKnightCustomiser.Instance.hipIndex + 1);
        }
        else if (CharacterManager.Instance.gender == 1)
        {
            FemaleKnightCustomiser.Instance.HipSelectionLeft();
            HipText.text = "Hip " + (FemaleKnightCustomiser.Instance.hipIndex + 1);
        }
    }
    public void LegRight()
    {
        if (CharacterManager.Instance.gender == 0)
        {
            MaleKnightCustomiser.Instance.LegSelectionRight();
            LegText.text = "Leg " + (MaleKnightCustomiser.Instance.legIndex + 1);
        }
        else if (CharacterManager.Instance.gender == 1)
        {
            FemaleKnightCustomiser.Instance.LegSelectionRight();
            LegText.text = "Leg " + (FemaleKnightCustomiser.Instance.legIndex + 1);
        }
    }

    public void LegLeft()
    {
        if (CharacterManager.Instance.gender == 0)
        {
            MaleKnightCustomiser.Instance.LegSelectionLeft();
            LegText.text = "Leg " + (MaleKnightCustomiser.Instance.legIndex + 1);
        }
        else if (CharacterManager.Instance.gender == 1)
        {
            FemaleKnightCustomiser.Instance.LegSelectionLeft();
            LegText.text = "Leg " + (FemaleKnightCustomiser.Instance.legIndex + 1);
        }
    }

    public void HairRight() 
    {
        if (CharacterManager.Instance.gender == 0)
        {
            MaleKnightCustomiser.Instance.HairSelectionRight();
            HairText.text = "Hair " + (MaleKnightCustomiser.Instance.hairIndex + 1);
        }
        else if (CharacterManager.Instance.gender == 1)
        {
            FemaleKnightCustomiser.Instance.HairSelectionRight();
            HairText.text = "Hair " + (FemaleKnightCustomiser.Instance.hairIndex + 1);
        }

    }
    public void HairLeft() 
    {
        if (CharacterManager.Instance.gender == 0)
        {
            MaleKnightCustomiser.Instance.HairSelectionLeft();
            HairText.text = "Hair " + (MaleKnightCustomiser.Instance.hairIndex + 1);
        }
        else if (CharacterManager.Instance.gender == 1)
        {
            FemaleKnightCustomiser.Instance.HairSelectionRight();
            HairText.text = "Hair " + (FemaleKnightCustomiser.Instance.hairIndex + 1);
        }
    }

    private void ResetChar()
    {
        HeadText.text = "Head 1";
        EyebrowText.text = "Eyebrows 1";
        FacialHairText.text = "Facial Hair 1";
        HeadArmorText.text = "Head Armor 1";
        TorsoText.text = "Torso 1";
        UpperArmText.text = "Upper Arm 1";
        LowerArmText.text = "Lower Arm 1";
        HandText.text = "Hand 1";
        HipText.text = "Hip 1";
        LegText.text = "Leg 1";
        HairText.text = "Hair 1";
    }
}
