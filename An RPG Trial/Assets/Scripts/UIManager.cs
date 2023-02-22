using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class UIManager : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerMoveHandler
{
    public GameObject FirstScreen;
    public GameObject SecondScreen;
    public GameObject ModularChar;
    public GameObject HeadSelectionPanel;
    public GameObject UpperBodySelectionPanel;
    public GameObject LowerBodySelectionPanel;
    public Animator CameraAnim;

    public GameObject maleChar;
    public GameObject femaleChar;
    public GameObject FacialHairPanel;

    private FemaleKnightCustomiser FemaleKnightCus;
    private MaleKnightCustomiser MaleKnightCus;
    private CharacterManager CharManager;

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

    private void Start()
    {
        charRotation = Vector3.zero;
        mouseDragSensitivity = 0.4f;

        MaleKnightCus = MaleKnightCustomiser.Instance;
        FemaleKnightCus = FemaleKnightCustomiser.Instance;
        CharManager = CharacterManager.Instance;

        ResetChar();
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

    public void OpenFirstScreen()
    {
        FirstScreen.SetActive(true);
        SecondScreen.SetActive(false);
        SetCameraToDefaultPos();
    }
    public void OpenSecondScreen() 
    {
        FirstScreen.SetActive(false);
        SecondScreen.SetActive(true);
    }

    public void SetCameraToHeadPos() 
    {
        HeadSelectionPanel.SetActive(true);
        UpperBodySelectionPanel.SetActive(false);
        LowerBodySelectionPanel.SetActive(false);
        CameraAnim.SetTrigger("ZoomHead");

    }
    public void SetCameraToUpperBodyPos()
    {
        HeadSelectionPanel.SetActive(false);
        UpperBodySelectionPanel.SetActive(true);
        LowerBodySelectionPanel.SetActive(false);
        CameraAnim.SetTrigger("ZoomBody");

    }

    public void SetCameraToLowerBodyPos()
    {
        HeadSelectionPanel.SetActive(false);
        UpperBodySelectionPanel.SetActive(false);
        LowerBodySelectionPanel.SetActive(true);
        CameraAnim.SetTrigger("ZoomHips");

    }

    public void SetCameraToDefaultPos()
    {
        HeadSelectionPanel.SetActive(false);
        UpperBodySelectionPanel.SetActive(false);
        LowerBodySelectionPanel.SetActive(false);
        CameraAnim.SetTrigger("ZoomOut");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (SecondScreen.activeSelf)
        {
            mouseInitialPos = Input.mousePosition;
            isCharRotating = true;
        }
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
        FemaleKnightCus.enabled = false;
        MaleKnightCus.enabled = true;
        MaleKnightCus.UpdateToDefault();
        FemaleKnightCus.UpdateToDefault();
        CharacterManager.Instance.gender = 0;
        FacialHairPanel.SetActive(true);
        maleChar.SetActive(true);
        femaleChar.SetActive(false);
    }

    public void SelectFemale()
    {
        FemaleKnightCus.enabled = true;
        MaleKnightCus.enabled = false;
        FemaleKnightCus.UpdateToDefault();
        FemaleKnightCus.UpdateToDefault();
        CharacterManager.Instance.gender = 1;
        FacialHairPanel.SetActive(false);
        maleChar.SetActive(false);
        femaleChar.SetActive(true);
    }

    public void HeadRight()
    {
        if(CharManager.gender == 0)
        {
            MaleKnightCus.HeadSelectionRight();
            HeadText.text = "Head " + (MaleKnightCus.headIndex + 1);
        }
        else if(CharManager.gender == 1){
            FemaleKnightCus.HeadSelectionRight();
            HeadText.text = "Head " + (FemaleKnightCus.headIndex + 1);
        }
    }

    public void HeadLeft()
    {
        if (CharManager.gender == 0)
        {
            MaleKnightCus.HeadSelectionLeft();
            HeadText.text = "Head " + (MaleKnightCus.headIndex + 1);
        }
        else if (CharManager.gender == 1)
        {
            FemaleKnightCus.HeadSelectionLeft();
            HeadText.text = "Head " + (FemaleKnightCus.headIndex + 1);
        }
    }

    public void EyebrowRight()
    {
        if (CharManager.gender == 0)
        {
            MaleKnightCus.EyebrowSelectionRight();
            EyebrowText.text = "Eyebrows " + (MaleKnightCus.eyebrowIndex + 1);
        }
        else if (CharManager.gender == 1)
        {
            FemaleKnightCus.EyebrowSelectionRight();
            EyebrowText.text = "Eyebrows " + (FemaleKnightCus.eyebrowIndex + 1);
        }
    }

    public void EyebrowLeft()
    {
        if (CharManager.gender == 0)
        {
            MaleKnightCus.EyebrowSelectionLeft();
            EyebrowText.text = "Eyebrows " + (MaleKnightCus.eyebrowIndex + 1);
        }
        else if (CharManager.gender == 1)
        {
            FemaleKnightCus.EyebrowSelectionLeft();
            EyebrowText.text = "Eyebrows " + (FemaleKnightCus.eyebrowIndex + 1);
        }
    }

    public void FacialHairRight()
    {
        MaleKnightCus.FacialHairSelectionRight();
        FacialHairText.text = "Facial Hair " + (MaleKnightCus.facialHairIndex + 1);
    }
    public void FacialHairLeft()
    {
        MaleKnightCus.FacialHairSelectionLeft();
        FacialHairText.text = "Facial Hair " + (MaleKnightCus.facialHairIndex + 1);
    }

    public void HeadArmorRight()
    {
        if (CharManager.gender == 0)
        {
            MaleKnightCus.HeadArmorSelectionRight();
            HeadArmorText.text = "Head Armor " + (MaleKnightCus.headArmorIndex + 1);
        }
        else if (CharManager.gender == 1)
        {
            FemaleKnightCus.HeadArmorSelectionRight();
            HeadArmorText.text = "Head Armor " + (FemaleKnightCus.headArmorIndex + 1);
        }
    }

    public void HeadArmorLeft()
    {
        if (CharManager.gender == 0)
        {
            MaleKnightCus.HeadArmorSelectionLeft();
            HeadArmorText.text = "Head Armor " + (MaleKnightCus.headArmorIndex + 1);
        }
        else if (CharManager.gender == 1)
        {
            FemaleKnightCus.HeadArmorSelectionLeft();
            HeadArmorText.text = "Head Armor " + (FemaleKnightCus.headArmorIndex + 1);

        }
    }
    public void TorsoRight()
    {
        if (CharManager.gender == 0)
        {
            MaleKnightCus.TorsoSelectionRight();
            TorsoText.text = "Torso " + (MaleKnightCus.torsoIndex + 1);
        }
        else if (CharManager.gender == 1)
        {
            FemaleKnightCus.TorsoSelectionRight();
            TorsoText.text = "Torso " + (FemaleKnightCus.torsoIndex + 1);
        }
    }

    public void TorsoLeft()
    {
        if (CharManager.gender == 0)
        {
            MaleKnightCus.TorsoSelectionLeft();
            TorsoText.text = "Torso " + (MaleKnightCus.torsoIndex + 1);
        }
        else if (CharManager.gender == 1)
        {
            FemaleKnightCus.TorsoSelectionLeft();
            TorsoText.text = "Torso " + (FemaleKnightCus.torsoIndex + 1);
        }
    }

    public void UpperArmRight()
    {
        if (CharManager.gender == 0)
        {
            MaleKnightCus.UpperArmSelectionRight();
            UpperArmText.text = "Upper Arm " + (MaleKnightCus.upperArmIndex + 1);
        }
        else if (CharManager.gender == 1)
        {
            FemaleKnightCus.UpperArmSelectionRight();
            UpperArmText.text = "Upper Arm " + (FemaleKnightCus.upperArmIndex + 1);
        }
    }

    public void UpperArmLeft()
    {
        if (CharManager.gender == 0)
        {
            MaleKnightCus.UpperArmSelectionLeft();
            UpperArmText.text = "Upper Arm " + (MaleKnightCus.upperArmIndex + 1);
        }
        else if (CharManager.gender == 1)
        {
            FemaleKnightCus.UpperArmSelectionLeft();
            UpperArmText.text = "Upper Arm " + (FemaleKnightCus.upperArmIndex + 1);
        }
    }

    public void LowerArmRight()
    {
        if (CharManager.gender == 0)
        {
            MaleKnightCus.LowerArmSelectionRight();
            LowerArmText.text = "Lower Arm " + (MaleKnightCus.lowerArmIndex + 1);
        }
        else if (CharManager.gender == 1)
        {
            FemaleKnightCus.LowerArmSelectionRight();
            LowerArmText.text = "Lower Arm " + (FemaleKnightCus.lowerArmIndex + 1);
        }
    }

    public void LowerArmLeft()
    {
        if (CharManager.gender == 0)
        {
            MaleKnightCus.LowerArmSelectionLeft();
            LowerArmText.text = "Lower Arm " + (MaleKnightCus.lowerArmIndex + 1);
        }
        else if (CharManager.gender == 1)
        {
            FemaleKnightCus.LowerArmSelectionLeft();
            LowerArmText.text = "Lower Arm " + (FemaleKnightCus.lowerArmIndex + 1);
        }
    }

    public void HandRight()
    {
        if (CharManager.gender == 0)
        {
            MaleKnightCus.HandSelectionRight();
            HandText.text = "Hand " + (MaleKnightCus.handIndex + 1);
        }
        else if (CharManager.gender == 1)
        {
            FemaleKnightCus.HandSelectionRight();
            HandText.text = "Hand " + (FemaleKnightCus.handIndex + 1);
        }
    }

    public void HandLeft()
    {
        if (CharManager.gender == 0)
        {
            MaleKnightCus.HandSelectionLeft();
            HandText.text = "Hand " + (MaleKnightCus.handIndex + 1);
        }
        else if (CharManager.gender == 1)
        {
            FemaleKnightCus.HandSelectionLeft();
            HandText.text = "Hand " + (FemaleKnightCus.handIndex + 1);
        }
    }
    public void HipRight()
    {
        if (CharManager.gender == 0)
        {
            MaleKnightCus.HipSelectionRight();
            HipText.text = "Hip " + (MaleKnightCus.hipIndex + 1);
        }
        else if (CharManager.gender == 1)
        {
            FemaleKnightCus.HipSelectionRight();
            HipText.text = "Hip " + (FemaleKnightCus.hipIndex + 1);
        }
    }

    public void HipLeft()
    {
        if (CharManager.gender == 0)
        {
            MaleKnightCus.HipSelectionLeft();
            HipText.text = "Hip " + (MaleKnightCus.hipIndex + 1);
        }
        else if (CharManager.gender == 1)
        {
            FemaleKnightCus.HipSelectionLeft();
            HipText.text = "Hip " + (FemaleKnightCus.hipIndex + 1);
        }
    }
    public void LegRight()
    {
        if (CharManager.gender == 0)
        {
            MaleKnightCus.LegSelectionRight();
            LegText.text = "Leg " + (MaleKnightCus.legIndex + 1);
        }
        else if (CharManager.gender == 1)
        {
            FemaleKnightCus.LegSelectionRight();
            LegText.text = "Leg " + (FemaleKnightCus.legIndex + 1);
        }
    }

    public void LegLeft()
    {
        if (CharManager.gender == 0)
        {
            MaleKnightCus.LegSelectionLeft();
            LegText.text = "Leg " + (MaleKnightCus.legIndex + 1);
        }
        else if (CharManager.gender == 1)
        {
            FemaleKnightCus.LegSelectionLeft();
            LegText.text = "Leg " + (FemaleKnightCus.legIndex + 1);
        }
    }

    public void HairRight() 
    {
        if (CharManager.gender == 0)
        {
            MaleKnightCus.HairSelectionRight();
            HairText.text = "Hair " + (MaleKnightCus.hairIndex + 1);
        }
        else if (CharManager.gender == 1)
        {
            FemaleKnightCus.HairSelectionRight();
            HairText.text = "Hair " + (FemaleKnightCus.hairIndex + 1);
        }

    }
    public void HairLeft() 
    {
        if (CharManager.gender == 0)
        {
            MaleKnightCus.HairSelectionLeft();
            HairText.text = "Hair " + (MaleKnightCus.hairIndex + 1);
        }
        else if (CharManager.gender == 1)
        {
            FemaleKnightCus.HairSelectionRight();
            HairText.text = "Hair " + (FemaleKnightCus.hairIndex + 1);
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
