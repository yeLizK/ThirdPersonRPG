using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FemaleKnightCustomiser : MonoBehaviour, Customiser
{
    private static FemaleKnightCustomiser _instance;
    public static FemaleKnightCustomiser Instance { get { return _instance; } }

    public FemaleKnightSO FemaleKnightSO;

    public Material raceMaterial;

    public SkinnedMeshRenderer Skins;
    public SkinnedMeshRenderer Eyebrows;
    public SkinnedMeshRenderer HeadArmors;
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

        raceMaterial = FemaleKnightSO.Materials[0];
        
    }


    public void HeadSelectionRight()
    {
        if (headArmorIndex == 0)
        {
            if (headIndex != FemaleKnightSO.SkinMesh.Length - 1)
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
                headIndex = FemaleKnightSO.SkinMesh.Length - 1;
            }
            HeadSelectionUpdate();
        }
    }

    public void HeadSelectionUpdate()
    {
        Skins.sharedMesh = FemaleKnightSO.SkinMesh[headIndex];
        Skins.sharedMaterial = raceMaterial;
        
    }

    public void HairSelectionRight()
    {
        if (headArmorIndex == 0)
        {
            if (hairIndex != FemaleKnightSO.HairMesh.Length - 1)
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
                hairIndex = FemaleKnightSO.HairMesh.Length - 1;
            }
            HairSelectionUpdate();
        }
    }

    public void HairSelectionUpdate()
    {
        Hair.sharedMesh = FemaleKnightSO.HairMesh[hairIndex];
        Hair.sharedMaterial = raceMaterial;
    }

    public void HeadArmorSelectionRight()
    {
        if (headArmorIndex != FemaleKnightSO.HeadArmorMesh.Length - 1)
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
            headArmorIndex = FemaleKnightSO.HeadArmorMesh.Length - 1;
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
        Eyebrows.sharedMesh = FemaleKnightSO.EyebrowsMesh[0];
        Hair.sharedMesh = FemaleKnightSO.HairMesh[0];
    }

    public void ReturnHeadSelections()
    {
        Skins.sharedMesh = FemaleKnightSO.SkinMesh[headIndex];
        Eyebrows.sharedMesh = FemaleKnightSO.EyebrowsMesh[eyebrowIndex];
        Hair.sharedMesh = FemaleKnightSO.HairMesh[hairIndex];
    }
    public void HeadArmorSelectionUpdate()
    {
        HeadArmors.sharedMesh = FemaleKnightSO.HeadArmorMesh[headArmorIndex];
        HeadArmors.sharedMaterial = raceMaterial;
    }
    public void EyebrowSelectionRight()
    {
        if (headArmorIndex == 0)
        {
            if (eyebrowIndex != FemaleKnightSO.EyebrowsMesh.Length - 1)
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
                eyebrowIndex = FemaleKnightSO.EyebrowsMesh.Length - 1;
            }
            EyebrowSelectionUpdate();
        }
    }

    public void EyebrowSelectionUpdate()
    {
        Eyebrows.sharedMesh = FemaleKnightSO.EyebrowsMesh[eyebrowIndex];
        Eyebrows.sharedMaterial = raceMaterial;
    }


    public void TorsoSelectionRight()
    {
        if (torsoIndex != FemaleKnightSO.TorsoMesh.Length - 1)
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
            torsoIndex = FemaleKnightSO.TorsoMesh.Length - 1;
        }

        TorsoSelectionUpdate();
    }

    public void TorsoSelectionUpdate()
    {
        Torsos.sharedMesh = FemaleKnightSO.TorsoMesh[torsoIndex];
        Torsos.sharedMaterial = raceMaterial;
    }

    public void UpperArmSelectionRight()
    {
        if (upperArmIndex != FemaleKnightSO.ArmUpperRightMesh.Length - 1)
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
            upperArmIndex = FemaleKnightSO.ArmUpperRightMesh.Length - 1;
        }

        UpperArmSelectionUpdate();
    }

    public void UpperArmSelectionUpdate()
    {
        ArmUpperRights.sharedMesh = FemaleKnightSO.ArmUpperRightMesh[upperArmIndex];
        ArmUpperLefts.sharedMesh = FemaleKnightSO.ArmUpperLeftMesh[upperArmIndex];
        ArmUpperRights.sharedMaterial = raceMaterial;
        ArmUpperLefts.sharedMaterial = raceMaterial;
    }

    public void LowerArmSelectionRight()
    {
        if (lowerArmIndex != FemaleKnightSO.ArmLowerRightMesh.Length - 1)
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
            lowerArmIndex = FemaleKnightSO.ArmLowerRightMesh.Length - 1;
        }

        LowerArmSelectionUpdate();
    }

    public void LowerArmSelectionUpdate()
    {
        ArmLowerRights.sharedMesh = FemaleKnightSO.ArmLowerRightMesh[lowerArmIndex];
        ArmLowerLefts.sharedMesh = FemaleKnightSO.ArmLowerLeftMesh[lowerArmIndex];
        ArmLowerRights.sharedMaterial = raceMaterial;
        ArmLowerLefts.sharedMaterial = raceMaterial;
    }

    public void HandSelectionRight()
    {
        if (handIndex != FemaleKnightSO.RightHandMesh.Length - 1)
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
            handIndex = FemaleKnightSO.RightHandMesh.Length - 1;
        }

        HandSelectionUpdate();
    }

    public void HandSelectionUpdate()
    {
        RightHands.sharedMesh = FemaleKnightSO.RightHandMesh[handIndex];
        LeftHands.sharedMesh = FemaleKnightSO.LeftHandMesh[handIndex];
        RightHands.sharedMaterial = raceMaterial;
        LeftHands.sharedMaterial = raceMaterial;
    }

    public void HipSelectionRight()
    {
        if (hipIndex != FemaleKnightSO.HipsMesh.Length - 1)
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
            hipIndex = FemaleKnightSO.HipsMesh.Length - 1;
        }
        HipsSelectionUpdate();
    }

    public void HipsSelectionUpdate()
    {
        Hips.sharedMesh = FemaleKnightSO.HipsMesh[hipIndex];
        Hips.sharedMaterial = raceMaterial;
    }

    public void LegSelectionRight()
    {
        if (legIndex != FemaleKnightSO.LegRightMesh.Length - 1)
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
            legIndex = FemaleKnightSO.LegRightMesh.Length - 1;
        }

        LegsSelectionUpdate();
    }

    public void LegsSelectionUpdate()
    {
        RightLegs.sharedMesh = FemaleKnightSO.LegRightMesh[legIndex];
        LeftLegs.sharedMesh = FemaleKnightSO.LegLeftMesh[legIndex];
        RightLegs.sharedMaterial = raceMaterial;
        LeftLegs.sharedMaterial = raceMaterial;
    }

    public void ChooseKnight()
    {
        raceMaterial = FemaleKnightSO.Materials[0];
    }
    public void ChooseFreeFolks()
    {
        raceMaterial = FemaleKnightSO.Materials[1];
    }
    public void ChooseHighBloods()
    {
        raceMaterial = FemaleKnightSO.Materials[2];
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
        Skins.sharedMaterial = raceMaterial;
    }
    public void ChangeGenderFromFemaleToMale()
    {
        MaleKnightCustomiser.Instance.headIndex = this.headIndex;
        MaleKnightCustomiser.Instance.eyebrowIndex = this.eyebrowIndex;
        MaleKnightCustomiser.Instance.facialHairIndex = this.facialHairIndex;
        MaleKnightCustomiser.Instance.headArmorIndex = this.headArmorIndex;
        MaleKnightCustomiser.Instance.torsoIndex = this.torsoIndex;
        MaleKnightCustomiser.Instance.upperArmIndex = this.upperArmIndex;
        MaleKnightCustomiser.Instance.lowerArmIndex = this.lowerArmIndex;
        MaleKnightCustomiser.Instance.handIndex = this.handIndex;
        MaleKnightCustomiser.Instance.hipIndex = this.hipIndex;
        MaleKnightCustomiser.Instance.legIndex = this.legIndex;
        MaleKnightCustomiser.Instance.hairIndex = hairIndex;
        MaleKnightCustomiser.Instance.RefreshSelections();
    }
    public void RefreshSelections()
    {
        Skins.sharedMesh = FemaleKnightSO.SkinMesh[headIndex];
        HeadArmors.sharedMesh = FemaleKnightSO.HeadArmorMesh[headArmorIndex];
        Torsos.sharedMesh = FemaleKnightSO.TorsoMesh[torsoIndex];
        ArmUpperRights.sharedMesh = FemaleKnightSO.ArmUpperRightMesh[upperArmIndex];
        ArmUpperLefts.sharedMesh = FemaleKnightSO.ArmUpperLeftMesh[upperArmIndex];
        ArmLowerRights.sharedMesh = FemaleKnightSO.ArmLowerRightMesh[lowerArmIndex];
        ArmLowerLefts.sharedMesh = FemaleKnightSO.ArmLowerLeftMesh[lowerArmIndex];
        RightHands.sharedMesh = FemaleKnightSO.RightHandMesh[handIndex];
        LeftHands.sharedMesh = FemaleKnightSO.LeftHandMesh[handIndex];
        Hips.sharedMesh = FemaleKnightSO.HipsMesh[hipIndex];
        RightLegs.sharedMesh = FemaleKnightSO.LegRightMesh[legIndex];
        LeftLegs.sharedMesh = FemaleKnightSO.LegLeftMesh[legIndex];
        Hair.sharedMesh = FemaleKnightSO.HairMesh[hairIndex];
        Eyebrows.sharedMesh = FemaleKnightSO.EyebrowsMesh[eyebrowIndex];
    }

    public void UpdateToDefault()
    {
        headIndex = 0;
        eyebrowIndex = 0;
        headArmorIndex = 0;
        torsoIndex = 0;
        upperArmIndex = 0;
        lowerArmIndex = 0;
        handIndex = 0;
        hipIndex = 0;
        legIndex = 0;
        hairIndex = 0;

        Skins.sharedMesh = FemaleKnightSO.SkinMesh[0];
        HeadArmors.sharedMesh = FemaleKnightSO.HeadArmorMesh[0];
        Torsos.sharedMesh = FemaleKnightSO.TorsoMesh[0];
        ArmUpperRights.sharedMesh = FemaleKnightSO.ArmUpperRightMesh[0];
        ArmUpperLefts.sharedMesh = FemaleKnightSO.ArmUpperLeftMesh[0];
        ArmLowerRights.sharedMesh = FemaleKnightSO.ArmLowerRightMesh[0];
        ArmLowerLefts.sharedMesh = FemaleKnightSO.ArmLowerLeftMesh[0];
        RightHands.sharedMesh = FemaleKnightSO.RightHandMesh[0];
        LeftHands.sharedMesh = FemaleKnightSO.LeftHandMesh[0];
        Hips.sharedMesh = FemaleKnightSO.HipsMesh[0];
        RightLegs.sharedMesh = FemaleKnightSO.LegRightMesh[0];
        LeftLegs.sharedMesh = FemaleKnightSO.LegLeftMesh[0];
        Hair.sharedMesh = FemaleKnightSO.HairMesh[0];
        Eyebrows.sharedMesh = FemaleKnightSO.EyebrowsMesh[0];
    }
}
