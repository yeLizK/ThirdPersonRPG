using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MaleKnightCustomiser : MonoBehaviour, Customiser
{
    private static MaleKnightCustomiser _instance;
    public static MaleKnightCustomiser Instance { get { return _instance; } }

    public MaleKnightSO MaleKnightSO;

    public Material raceMaterial;

    public SkinnedMeshRenderer Skins;
    public SkinnedMeshRenderer HeadArmors;
    public SkinnedMeshRenderer Eyebrows;
    public SkinnedMeshRenderer FacialHairs;
    public SkinnedMeshRenderer Torsos;
    public SkinnedMeshRenderer ArmUpperRights;
    public SkinnedMeshRenderer ArmUpperLefts;
    public SkinnedMeshRenderer ArmLowerRights;
    public SkinnedMeshRenderer ArmLowerLefts;
    public SkinnedMeshRenderer RightHands;
    public SkinnedMeshRenderer LeftHands;
    public SkinnedMeshRenderer Hips;
    public SkinnedMeshRenderer RightLegs;
    public SkinnedMeshRenderer LeftLegs;
    public SkinnedMeshRenderer Hair;

    [HideInInspector]
    public int headIndex, eyebrowIndex, facialHairIndex, headArmorIndex, torsoIndex, upperArmIndex, lowerArmIndex, handIndex, hipIndex, legIndex, hairIndex;

    private void Awake()
    {
        if (_instance != null && _instance != this)
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
        UpdateToDefault();

        raceMaterial = MaleKnightSO.Materials[0];
    }
    public void HeadSelectionRight()
    {
        if (headArmorIndex == 0)
        {
            if (headIndex != MaleKnightCustomiser.Instance.MaleKnightSO.SkinMesh.Length - 1)
            {
                headIndex++;
            }
            else
            {
                headIndex = 0;
            }
            HeadSelectionUpdate();
        }

    }

    public void HeadSelectionLeft()
    {
        if (headArmorIndex == 0)
        {
            if (headIndex != 0)
            {
                headIndex--;
            }
            else
            {
                headIndex = MaleKnightSO.SkinMesh.Length - 1;
            }
            HeadSelectionUpdate();
        }
    }
    public void HeadSelectionUpdate()
    {
        Skins.sharedMesh = MaleKnightSO.SkinMesh[headIndex];
        Skins.sharedMaterial = raceMaterial;
        
    }

    public void HairSelectionRight()
    {
        if (headArmorIndex == 0)
        {
            if (hairIndex != MaleKnightSO.HairMesh.Length - 1)
            {
                hairIndex++;
            }
            else
            {
                hairIndex = 0;
            }
            HairSelectionUpdate();
        }

    }

    public void HairSelectionLeft()
    {
        if (headArmorIndex == 0)
        {
            if (hairIndex != 0)
            {
                hairIndex--;
            }
            else
            {
                hairIndex = MaleKnightSO.HairMesh.Length - 1;
            }
            HairSelectionUpdate();
        }
    }

    public void HairSelectionUpdate()
    {
        Hair.sharedMesh = MaleKnightSO.HairMesh[hairIndex];
        Hair.sharedMaterial = raceMaterial;
    }
    public void EyebrowSelectionRight()
    {
        if (headArmorIndex == 0)
        {
            if (eyebrowIndex != MaleKnightSO.EyebrowsMesh.Length - 1)
            {
                eyebrowIndex++;
            }
            else
            {
                eyebrowIndex = 0;
            }
            EyebrowSelectionUpdate();
        }
    }

    public void EyebrowSelectionLeft()
    {
        if (headArmorIndex == 0)
        {
            if (eyebrowIndex != 0)
            {
                eyebrowIndex--;
            }
            else
            {
                eyebrowIndex = MaleKnightSO.EyebrowsMesh.Length - 1;
            }
            EyebrowSelectionUpdate();
        }
    }

    public void EyebrowSelectionUpdate()
    {
        Eyebrows.sharedMesh = MaleKnightSO.EyebrowsMesh[eyebrowIndex];
        Eyebrows.sharedMaterial = raceMaterial;
    }

    public void FacialHairSelectionRight() 
    {
        if (headArmorIndex == 0)
        {
            if (facialHairIndex != MaleKnightSO.FacialHairMesh.Length - 1)
            {
                facialHairIndex++;
            }
            else
            {
                facialHairIndex = 0;
            }
            FacialHairSelectionUpdate();
        }
    }
    public void FacialHairSelectionLeft() 
    {
        if (headArmorIndex == 0)
        {
            if (facialHairIndex != 0)
            {
                facialHairIndex--;
            }
            else
            {
                facialHairIndex = MaleKnightSO.FacialHairMesh.Length - 1;
            }

            FacialHairSelectionUpdate();
        }
    }

    public void FacialHairSelectionUpdate()
    {
        FacialHairs.sharedMesh = MaleKnightSO.FacialHairMesh[facialHairIndex];
        FacialHairs.sharedMaterial = raceMaterial;
    }

    public void HeadArmorSelectionRight()
    {
        if (headArmorIndex != MaleKnightSO.HeadArmorMesh.Length - 1)
        {
            headArmorIndex++;
        }
        else
        {
            headArmorIndex = 0;
        }
        HeadArmorSelectionUpdate();


        if (headArmorIndex != 0)
        {
            HideHeadSelections();
        }
        else
        {
            ReturnHeadSelections();
        }
    }

    public void HeadArmorSelectionLeft()
    {
        if (headArmorIndex != 0)
        {
            headArmorIndex--;
        }
        else
        {
            headArmorIndex = MaleKnightSO.HeadArmorMesh.Length - 1;
        }

        HeadArmorSelectionUpdate();

        if (headArmorIndex != 0)
        {
            HideHeadSelections();
        }
        else
        {
            ReturnHeadSelections();
        }
    }

    public void HideHeadSelections()
    {
        Skins.sharedMesh = null;
        Hair.sharedMesh = MaleKnightSO.HairMesh[0];
        Eyebrows.sharedMesh = MaleKnightSO.EyebrowsMesh[0]; ;
        FacialHairs.sharedMesh = MaleKnightSO.FacialHairMesh[0];
    }

    public void ReturnHeadSelections()
    {
        Skins.sharedMesh = MaleKnightSO.SkinMesh[headIndex];
        Eyebrows.sharedMesh = MaleKnightSO.EyebrowsMesh[eyebrowIndex];
        FacialHairs.sharedMesh = MaleKnightSO.FacialHairMesh[facialHairIndex];
        Hair.sharedMesh = MaleKnightSO.HairMesh[hairIndex];
    }

    public void HeadArmorSelectionUpdate()
    {
        HeadArmors.sharedMesh = MaleKnightSO.HeadArmorMesh[headArmorIndex];
        HeadArmors.sharedMaterial = raceMaterial;
    }
    public void TorsoSelectionRight()
    {
        if (torsoIndex != MaleKnightSO.TorsoMesh.Length - 1)
        {
            torsoIndex++;
        }
        else
        {
            torsoIndex = 0;
        }
        TorsoSelectionUpdate();
    }
    public void TorsoSelectionLeft()
    {
        if (torsoIndex != 0)
        {
            torsoIndex--;
        }
        else
        {
            torsoIndex = MaleKnightSO.TorsoMesh.Length - 1;
        }

        TorsoSelectionUpdate();
    }

    public void TorsoSelectionUpdate()
    {
        Torsos.sharedMesh = MaleKnightSO.TorsoMesh[torsoIndex];
        Torsos.sharedMaterial = raceMaterial;
    }

    public void UpperArmSelectionRight() 
    {
        if (upperArmIndex != MaleKnightSO.ArmUpperRightMesh.Length - 1)
        {
            upperArmIndex++;
        }
        else
        {
            upperArmIndex = 0;
        }

        UpperArmSelectionUpdate();
    }
    public void UpperArmSelectionLeft()
    {
        if (upperArmIndex != 0)
        {
            upperArmIndex--;
        }
        else
        {
            upperArmIndex = MaleKnightSO.ArmUpperRightMesh.Length - 1;
        }

        UpperArmSelectionUpdate();
    }

    public void UpperArmSelectionUpdate()
    {
        ArmUpperRights.sharedMesh = MaleKnightSO.ArmUpperRightMesh[upperArmIndex];
        ArmUpperLefts.sharedMesh = MaleKnightSO.ArmUpperLeftMesh[upperArmIndex];
        ArmUpperRights.sharedMaterial = raceMaterial;
        ArmUpperLefts.sharedMaterial = raceMaterial;
    }

    public void LowerArmSelectionRight() 
    {
        if (lowerArmIndex != MaleKnightSO.ArmLowerRightMesh.Length - 1)
        {
            lowerArmIndex++;
        }
        else
        {
            lowerArmIndex = 0;
        }

        LowerArmSelectionUpdate();
    }
    public void LowerArmSelectionLeft()
    {
        if (lowerArmIndex != 0)
        {
            lowerArmIndex--;
        }
        else
        {
            lowerArmIndex = MaleKnightSO.ArmLowerRightMesh.Length - 1;
        }

        LowerArmSelectionUpdate();
    }

    public void LowerArmSelectionUpdate()
    {
        ArmLowerRights.sharedMesh = MaleKnightSO.ArmLowerRightMesh[lowerArmIndex];
        ArmLowerLefts.sharedMesh = MaleKnightSO.ArmLowerLeftMesh[lowerArmIndex];
        ArmLowerRights.sharedMaterial = raceMaterial;
        ArmLowerLefts.sharedMaterial = raceMaterial;
    }

    public void HandSelectionRight()
    {
        if (handIndex != MaleKnightSO.RightHandMesh.Length - 1)
        {
            handIndex++;
        }
        else
        {
            handIndex = 0;
        }

        HandSelectionUpdate();
    }
    public void HandSelectionLeft()
    {
        if (handIndex != 0)
        {
            handIndex--;
        }
        else
        {
            handIndex = MaleKnightSO.RightHandMesh.Length - 1;
        }

        HandSelectionUpdate();
    }

    public void HandSelectionUpdate()
    {
        RightHands.sharedMesh = MaleKnightSO.RightHandMesh[handIndex];
        LeftHands.sharedMesh = MaleKnightSO.LeftHandMesh[handIndex];
        RightHands.sharedMaterial = raceMaterial;
        LeftHands.sharedMaterial = raceMaterial;
    }

    public void HipSelectionRight()
    {
        if (hipIndex != MaleKnightSO.HipsMesh.Length - 1)
        {
            hipIndex++;
        }
        else
        {
            hipIndex = 0;
        }

        HipsSelectionUpdate();
    }
    public void HipSelectionLeft()
    {
        if (hipIndex != 0)
        {
            hipIndex--;
        }
        else
        {
            hipIndex = MaleKnightSO.HipsMesh.Length - 1;
        }
        HipsSelectionUpdate();
    }

    public void HipsSelectionUpdate()
    {
        Hips.sharedMesh = MaleKnightSO.HipsMesh[hipIndex];
        Hips.sharedMaterial = raceMaterial;
    }

    public void LegSelectionRight() 
    {
        if (legIndex != MaleKnightSO.LegRightMesh.Length - 1)
        {
            legIndex++;
        }
        else
        {
            legIndex = 0;
        }

        LegsSelectionUpdate();
    }
    public void LegSelectionLeft()
    {
        if (legIndex != 0)
        {
            legIndex--;
        }
        else
        {
            legIndex = MaleKnightSO.LegRightMesh.Length - 1;
        }

        LegsSelectionUpdate();
    }

    public void LegsSelectionUpdate()
    {
        RightLegs.sharedMesh = MaleKnightSO.LegRightMesh[legIndex];
        LeftLegs.sharedMesh = MaleKnightSO.LegLeftMesh[legIndex];
        RightLegs.sharedMaterial = raceMaterial;
        LeftLegs.sharedMaterial = raceMaterial;
    }

    public void ChooseKnight()
    {
        raceMaterial = MaleKnightSO.Materials[0];
    }
    public void ChooseFreeFolks()
    {
        raceMaterial = MaleKnightSO.Materials[1];
    }
    public void ChooseHighBloods()
    {
        raceMaterial = MaleKnightSO.Materials[2];
    }

    public void UpdateMaterial()
    {
        RightLegs.sharedMaterial = raceMaterial;
        LeftLegs.sharedMaterial = raceMaterial;
        Hips.sharedMaterial = raceMaterial;
        RightHands.sharedMaterial = raceMaterial;
        LeftHands.sharedMaterial = raceMaterial;
        ArmLowerRights.sharedMaterial = raceMaterial;
        ArmLowerLefts.sharedMaterial = raceMaterial;
        ArmUpperRights.sharedMaterial = raceMaterial;
        ArmUpperLefts.sharedMaterial = raceMaterial;
        Torsos.sharedMaterial = raceMaterial;
        HeadArmors.sharedMaterial = raceMaterial;
        FacialHairs.sharedMaterial = raceMaterial;
        Eyebrows.sharedMaterial = raceMaterial;
        Skins.sharedMaterial = raceMaterial;
    }

    public void UpdateToDefault()
    {
        headIndex = 0;
        eyebrowIndex = 0;
        facialHairIndex = 0;
        headArmorIndex = 0;
        torsoIndex = 0;
        upperArmIndex = 0;
        lowerArmIndex = 0;
        handIndex = 0;
        hipIndex = 0;
        legIndex = 0;
        hairIndex = 0;

        Skins.sharedMesh = MaleKnightSO.SkinMesh[0];
        HeadArmors.sharedMesh = MaleKnightSO.HeadArmorMesh[0];
        Torsos.sharedMesh = MaleKnightSO.TorsoMesh[0];
        ArmUpperRights.sharedMesh = MaleKnightSO.ArmUpperRightMesh[0];
        ArmUpperLefts.sharedMesh = MaleKnightSO.ArmUpperLeftMesh[0];
        ArmLowerRights.sharedMesh = MaleKnightSO.ArmLowerRightMesh[0];
        ArmLowerLefts.sharedMesh = MaleKnightSO.ArmLowerLeftMesh[0];
        RightHands.sharedMesh = MaleKnightSO.RightHandMesh[0];
        LeftHands.sharedMesh = MaleKnightSO.LeftHandMesh[0];
        Hips.sharedMesh = MaleKnightSO.HipsMesh[0];
        RightLegs.sharedMesh = MaleKnightSO.LegRightMesh[0];
        LeftLegs.sharedMesh = MaleKnightSO.LegLeftMesh[0];
        Hair.sharedMesh = MaleKnightSO.HairMesh[0];
        Eyebrows.sharedMesh = MaleKnightSO.EyebrowsMesh[0];
        FacialHairs.sharedMesh = MaleKnightSO.FacialHairMesh[0];

    }

    public void Randomise()
    {
        Skins.sharedMesh = MaleKnightSO.SkinMesh[Random.Range(0, MaleKnightSO.SkinMesh.Length)];
        HeadArmors.sharedMesh = MaleKnightSO.HeadArmorMesh[Random.Range(0, MaleKnightSO.HeadArmorMesh.Length)];
        Eyebrows.sharedMesh = MaleKnightSO.EyebrowsMesh[Random.Range(0, MaleKnightSO.EyebrowsMesh.Length)];
        FacialHairs.sharedMesh = MaleKnightSO.FacialHairMesh[Random.Range(0, MaleKnightSO.FacialHairMesh.Length)];
        Torsos.sharedMesh = MaleKnightSO.TorsoMesh[Random.Range(0, MaleKnightSO.TorsoMesh.Length)];
        int armUpperRandomIndex = Random.Range(0, MaleKnightSO.ArmUpperRightMesh.Length);
        ArmUpperRights.sharedMesh = MaleKnightSO.ArmUpperRightMesh[armUpperRandomIndex];
        ArmUpperLefts.sharedMesh = MaleKnightSO.ArmUpperLeftMesh[armUpperRandomIndex];
        int armLowerRandomIndex = Random.Range(0, MaleKnightSO.ArmLowerRightMesh.Length);
        ArmLowerRights.sharedMesh = MaleKnightSO.ArmLowerRightMesh[armLowerRandomIndex];
        ArmLowerLefts.sharedMesh = MaleKnightSO.ArmLowerLeftMesh[armLowerRandomIndex];
        int handIndex = Random.Range(0, MaleKnightSO.RightHandMesh.Length);
        RightHands.sharedMesh = MaleKnightSO.RightHandMesh[handIndex];
        LeftHands.sharedMesh = MaleKnightSO.LeftHandMesh[handIndex];
        Hips.sharedMesh = MaleKnightSO.HipsMesh[Random.Range(0, MaleKnightSO.HipsMesh.Length)];
        int legIndex = Random.Range(0, MaleKnightSO.LegRightMesh.Length);
        RightLegs.sharedMesh = MaleKnightSO.LegRightMesh[legIndex];
        LeftLegs.sharedMesh = MaleKnightSO.LegLeftMesh[legIndex];
    }

}
