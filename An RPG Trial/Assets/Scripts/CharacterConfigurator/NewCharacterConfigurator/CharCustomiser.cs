using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharCustomiser : MonoBehaviour, IDataPersistence
{
    private static CharCustomiser _instance;
    public static CharCustomiser Instance { get { return _instance; } }

    private int gender; //0-female 0-male
    private int skinColor; // 0-black, 1-brown, 2-white

    [HideInInspector]public int clotheIndex, hairIndex;
    private int clotheColourIndex;
    private int hairColourIndex;
    private int weaponIndex;
    

    [SerializeField] private CharacterCustomiserSO CharSO;

    [SerializeField] private GameObject BaseHolder, HairHolder, RightArmHolder;


    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this);
        }
        else _instance = this;
    }

    private void Start()
    {
        clotheIndex = 0;
        clotheColourIndex = 0;
        hairIndex = 0;
        hairColourIndex = 0;
        weaponIndex = 0;
        skinColor = 0;
        gender = 0;
    }

    public void LoadData(GameData data)
    {
        this.gender = data.gender;
        this.skinColor = data.skinColor;
        this.clotheIndex = data.clotheIndex;
        this.clotheColourIndex = data.clotheColorIndex;
        this.hairIndex = data.hairIndex;
        this.hairColourIndex = data.hairColourIndex;
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

    private void ChangeBlackFemaleClothes(int colorIndex)
    {
        if (colorIndex == 0)
        {
            BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.BlackFemaleBlackClothes[clotheIndex];
        }
        else if (colorIndex == 1)
        {
            BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.BlackFemaleBlueClothes[clotheIndex];
        }
        else if (colorIndex == 2)
        {
            BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.BlackFemaleCyanClothes[clotheIndex];
        }
        else if (colorIndex == 3)
        {
            BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.BlackFemalePurpleClothes[clotheIndex];
        }
        else if (colorIndex == 4)
        {
            BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.BlackFemaleWhiteClothes[clotheIndex];
        }
    }

    private void ChangeBrownFemaleClothes(int colorIndex)
    {
        if (colorIndex == 0)
        {
            BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.BrownFemaleBlackClothes[clotheIndex];
        }
        else if (colorIndex == 1)
        {
            BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.BrownFemaleBlueClothes[clotheIndex];
        }
        else if (colorIndex == 2)
        {
            BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.BrownFemaleCyanClothes[clotheIndex];
        }
        else if (colorIndex == 3)
        {
            BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.BrownFemalePurpleClothes[clotheIndex];
        }
        else if (colorIndex == 4)
        {
            BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.BrownFemaleWhiteClothes[clotheIndex];
        }
    }

    private void ChangeWhiteFemaleClothes(int colorIndex)
    {
        if (colorIndex == 0)
        {
            BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.WhiteFemaleBlackClothes[clotheIndex];
        }
        else if (colorIndex == 1)
        {
            BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.WhiteFemaleBlueClothes[clotheIndex];
        }
        else if (colorIndex == 2)
        {
            BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.WhiteFemaleCyanClothes[clotheIndex];
        }
        else if (colorIndex == 3)
        {
            BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.WhiteFemalePurpleClothes[clotheIndex];
        }
        else if (colorIndex == 4)
        {
            BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.WhiteFemaleWhiteClothes[clotheIndex];
        }
    }

    private void ChangeBlackMaleClothes(int colorIndex)
    {
        if (colorIndex == 0)
        {
            BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.BlackMaleBlackClothes[clotheIndex];
        }
        else if (colorIndex == 1)
        {
            BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.BlackMaleBlueClothes[clotheIndex];
        }
        else if (colorIndex == 2)
        {
            BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.BlackMaleCyanClothes[clotheIndex];
        }
        else if (colorIndex == 3)
        {
            BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.BlackMalePurpleClothes[clotheIndex];
        }
        else if (colorIndex == 4)
        {
            BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.BlackMaleWhiteClothes[clotheIndex];
        }
    }

    private void ChangeBrownMaleClothes(int colorIndex)
    {
        if (clotheColourIndex == 0)
        {
            BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.BrownMaleBlackClothes[clotheIndex];
        }
        else if (clotheColourIndex == 1)
        {
            BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.BrownMaleBlueClothes[clotheIndex];
        }
        else if (clotheColourIndex == 2)
        {
            BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.BrownMaleCyanClothes[clotheIndex];
        }
        else if (clotheColourIndex == 3)
        {
            BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.BrownMalePurpleClothes[clotheIndex];
        }
        else if (clotheColourIndex == 4)
        {
            BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.BrownMaleWhiteClothes[clotheIndex];
        }
    }

    private void ChangeWhiteMaleClothes(int colorIndex)
    {
        if (clotheColourIndex == 0)
        {
            BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.WhiteMaleBlackClothes[clotheIndex];
        }
        else if (clotheColourIndex == 1)
        {
            BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.WhiteMaleBlueClothes[clotheIndex];
        }
        else if (clotheColourIndex == 2)
        {
            BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.WhiteMaleCyanClothes[clotheIndex];
        }
        else if (clotheColourIndex == 3)
        {
            BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.WhiteMalePurpleClothes[clotheIndex];
        }
        else if (clotheColourIndex == 4)
        {
            BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.WhiteMaleWhiteClothes[clotheIndex];
        }
    }
    public void SelectFemale()
    {
        if(skinColor == 0)
        {
            if (clotheIndex >= CharSO.BlackFemaleBlackClothes.Length)
            {
                clotheIndex = 0;
            }
            ChangeBlackFemaleClothes(clotheColourIndex);
        }
        else if(skinColor ==1)
        {
            if (clotheIndex >= CharSO.BrownFemaleBlackClothes.Length)
            {
                clotheIndex = 0;
            }
            ChangeBrownFemaleClothes(clotheColourIndex);
        }
        else if(skinColor ==2)
        {
            if (clotheIndex >= CharSO.WhiteFemaleBlackClothes.Length)
            {
                clotheIndex = 0;
            }
            ChangeWhiteFemaleClothes(clotheColourIndex);
        }
        gender = 0;
    }

    public void SelectMale()
    {
        if (skinColor == 0)
        {
            if (clotheIndex >= CharSO.BlackMaleBlackClothes.Length)
            {
                clotheIndex = 0;
            }
            ChangeBlackMaleClothes(clotheColourIndex);
        }
        else if (skinColor == 1)
        {
            if (clotheIndex >= CharSO.BrownMaleBlackClothes.Length)
            {
                clotheIndex = 0;
            }
            ChangeBrownMaleClothes(clotheColourIndex);
        }
        else if (skinColor == 2)
        {
            if (clotheIndex >= CharSO.WhiteFemaleBlackClothes.Length)
            {
                clotheIndex = 0;
            }
            ChangeWhiteMaleClothes(clotheColourIndex);
        }
        gender = 1;
    }

    public void ChangeSkinColorToBlack()
    {
        if (gender == 0)
        {
            ChangeBlackFemaleClothes(clotheColourIndex);
        }
        else if (gender == 1)
        {
            ChangeBlackMaleClothes(clotheColourIndex);
        }
        skinColor = 0;
    }

    public void ChangeSkinColorToBrown()
    {
        if (gender == 0)
        {
            ChangeBrownFemaleClothes(clotheColourIndex);
        }
        else if (gender == 1)
        {
            ChangeBrownMaleClothes(clotheColourIndex);
        }
        skinColor = 1;
    }    

    public void ChangeSkinColorToWhite()
    {
        if (gender == 0)
        {
            ChangeWhiteFemaleClothes(clotheColourIndex);
        }
        else if (gender == 1)
        {
            ChangeWhiteMaleClothes(clotheColourIndex);
        }
        skinColor = 2;
    }

    public void ChangeClothingRightSelection()
    {
        clotheIndex++;
        if(gender==0)
        {
            if(skinColor==0)
            {
                if (clotheIndex >= CharSO.BlackFemaleBlackClothes.Length)
                {
                    clotheIndex = 0;
                }
                ChangeBlackFemaleClothes(clotheColourIndex);

            }else if(skinColor==1)
            {
                if (clotheIndex >= CharSO.BrownFemaleBlackClothes.Length)
                {
                    clotheIndex = 0;
                }
                ChangeBlackFemaleClothes(clotheColourIndex);
            }
            else if (skinColor == 2)
            {
                if (clotheIndex >= CharSO.WhiteFemaleBlackClothes.Length)
                {
                    clotheIndex = 0;
                }
                ChangeWhiteFemaleClothes(clotheColourIndex);

            }
        }
        else if (gender == 1)
        {
            if (skinColor == 0)
            {
                if (clotheIndex >= CharSO.BlackMaleBlackClothes.Length)
                {
                    clotheIndex = 0;
                }
                ChangeBlackMaleClothes(clotheColourIndex);

            }
            else if (skinColor == 1)
            {
                if (clotheIndex >= CharSO.BrownMaleBlackClothes.Length)
                {
                    clotheIndex = 0;
                }
                ChangeBlackMaleClothes(clotheColourIndex);
            }
            else if (skinColor == 2)
            {
                if (clotheIndex >= CharSO.WhiteMaleBlackClothes.Length)
                {
                    clotheIndex = 0;
                }
                ChangeWhiteMaleClothes(clotheColourIndex);
            }
        }
    }

    public void ChangeClothingLeftSelection()
    {
        clotheIndex--;
        if (gender == 0)
        {
            if (skinColor == 0)
            {
                if (clotheIndex <0)
                {
                    clotheIndex = CharSO.BlackFemaleBlackClothes.Length - 1;
                }
                ChangeBlackFemaleClothes(clotheColourIndex);
            }
            else if (skinColor == 1)
            {
                if (clotheIndex < 0)
                {
                    clotheIndex = CharSO.BrownFemaleBlackClothes.Length - 1;
                }
                ChangeBrownFemaleClothes(clotheColourIndex);
            }
            else if (skinColor == 2)
            {
                if (clotheIndex < 0)
                {
                    clotheIndex = CharSO.WhiteFemaleBlackClothes.Length - 1;
                }
                ChangeWhiteFemaleClothes(clotheColourIndex);
            }
        }
        else if (gender == 1)
        {
            if (skinColor == 0)
            {
                if (clotheIndex < 0)
                {
                    clotheIndex = CharSO.BlackMaleBlackClothes.Length - 1;
                }
                ChangeBlackMaleClothes(clotheColourIndex);
            }
            else if (skinColor == 1)
            {
                if (clotheIndex < 0)
                {
                    clotheIndex = CharSO.BrownMaleBlackClothes.Length - 1;
                }
                ChangeBrownMaleClothes(clotheColourIndex);
            }
            else if (skinColor == 2)
            {
                if (clotheIndex < 0)
                {
                    clotheIndex = CharSO.WhiteMaleBlackClothes.Length - 1;
                }
                ChangeWhiteMaleClothes(clotheColourIndex);
            }
        }
    }

    public void ChangeHairRightSelection()
    {
        hairIndex++;
        if (hairIndex >= CharSO.HairList.Length)
        {
            hairIndex = 0;
        }
        InstantiateHair(hairIndex);
    }
    public void ChangeHairLeftSelection()
    {
        hairIndex--;

        if (hairIndex < 0)
        {
            hairIndex = CharSO.HairList.Length-1;
        }
        InstantiateHair(hairIndex);
    }

    private void InstantiateHair(int hairIndex)
    {
        GameObject tempHair;
        if (HairHolder.transform.childCount > 0)
        {
            foreach (Transform child in HairHolder.GetComponentsInChildren<Transform>())
            {
                if (child.gameObject != HairHolder) Destroy(child.gameObject);
            }
        }
        tempHair = Instantiate(CharSO.HairList[hairIndex], HairHolder.transform);
        tempHair.transform.parent = HairHolder.transform;
    }

    

    public void ChangeClotheColorToBlack()
    {
        if(gender == 0)
        {
            if(skinColor==0)
            {
                BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.BlackFemaleBlackClothes[clotheIndex];
            }else if(skinColor==1)
            {
                BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.BrownFemaleBlackClothes[clotheIndex];
            }
            else if (skinColor == 2)
            {
                BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.WhiteFemaleBlackClothes[clotheIndex];
            }
        }else if(gender == 1)
        {
            if (skinColor == 0)
            {
                BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.BlackMaleBlackClothes[clotheIndex];
            }
            else if (skinColor == 1)
            {
                BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.BrownMaleBlackClothes[clotheIndex];
            }
            else if (skinColor == 2)
            {
                BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.WhiteMaleBlackClothes[clotheIndex];
            }
        }
        clotheColourIndex = 0;
    }

    public void ChangeClotheColorToBlue()
    {
        if (gender == 0)
        {
            if (skinColor == 0)
            {
                BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.BlackFemaleBlueClothes[clotheIndex];
            }
            else if (skinColor == 1)
            {
                BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.BrownFemaleBlueClothes[clotheIndex];
            }
            else if (skinColor == 2)
            {
                BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.WhiteFemaleBlueClothes[clotheIndex];
            }
        }
        else if (gender == 1)
        {
            if (skinColor == 0)
            {
                BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.BlackMaleBlueClothes[clotheIndex];
            }
            else if (skinColor == 1)
            {
                BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.BrownMaleBlueClothes[clotheIndex];
            }
            else if (skinColor == 2)
            {
                BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.WhiteMaleBlueClothes[clotheIndex];
            }
        }
        clotheColourIndex = 1;

    }

    public void ChangeClotheColorToCyan()
    {
        if (gender == 0)
        {
            if (skinColor == 0)
            {
                BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.BlackFemaleCyanClothes[clotheIndex];
            }
            else if (skinColor == 1)
            {
                BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.BrownFemaleCyanClothes[clotheIndex];
            }
            else if (skinColor == 2)
            {
                BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.WhiteFemaleCyanClothes[clotheIndex];
            }
        }
        else if (gender == 1)
        {
            if (skinColor == 0)
            {
                BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.BlackMaleCyanClothes[clotheIndex];
            }
            else if (skinColor == 1)
            {
                BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.BrownMaleCyanClothes[clotheIndex];
            }
            else if (skinColor == 2)
            {
                BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.WhiteMaleCyanClothes[clotheIndex];
            }
        }
        clotheColourIndex = 2;

    }

    public void ChangeClotheColorToPurple()
    {
        if (gender == 0)
        {
            if (skinColor == 0)
            {
                BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.BlackFemalePurpleClothes[clotheIndex];
            }
            else if (skinColor == 1)
            {
                BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.BrownFemalePurpleClothes[clotheIndex];
            }
            else if (skinColor == 2)
            {
                BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.WhiteFemalePurpleClothes[clotheIndex];
            }
        }
        else if (gender == 1)
        {
            if (skinColor == 0)
            {
                BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.BlackMalePurpleClothes[clotheIndex];
            }
            else if (skinColor == 1)
            {
                BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.BrownMalePurpleClothes[clotheIndex];
            }
            else if (skinColor == 2)
            {
                BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.WhiteMalePurpleClothes[clotheIndex];
            }
        }
        clotheColourIndex = 3;

    }

    public void ChangeClotheColorToWhite()
    {
        if (gender == 0)
        {
            if (skinColor == 0)
            {
                BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.BlackFemaleWhiteClothes[clotheIndex];
            }
            else if (skinColor == 1)
            {
                BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.BrownFemaleWhiteClothes[clotheIndex];
            }
            else if (skinColor == 2)
            {
                BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.WhiteFemaleWhiteClothes[clotheIndex];
            }
        }
        else if (gender == 1)
        {
            if (skinColor == 0)
            {
                BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.BlackMaleWhiteClothes[clotheIndex];
            }
            else if (skinColor == 1)
            {
                BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.BrownMaleWhiteClothes[clotheIndex];
            }
            else if (skinColor == 2)
            {
                BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.WhiteMaleWhiteClothes[clotheIndex];
            }
        }
        clotheColourIndex = 4;

    }

    public void ChangeHairColorToBlack()
    {
        if(HairHolder.transform.childCount > 0)
        {
            hairColourIndex = 0;
            ChangeHairColour(hairColourIndex);
        }
    }

    public void ChangeHairColorToYellow()
    {
        if (HairHolder.transform.childCount > 0)
        {
            hairColourIndex = 1;
            ChangeHairColour(hairColourIndex);
        }
    }
    public void ChangeHairColorToBrown()
    {
        if (HairHolder.transform.childCount > 0)
        {
            hairColourIndex = 2;
            ChangeHairColour(hairColourIndex);
        }
    }
    public void ChangeHairColorToCyan()
    {
        if (HairHolder.transform.childCount > 0)
        {
            hairColourIndex = 3;
            ChangeHairColour(hairColourIndex);
        }
    }
    public void ChangeHairColorToPurple()
    {
        if (HairHolder.transform.childCount > 0)
        {
            hairColourIndex = 4;
            ChangeHairColour(hairColourIndex);
        }
    }
    public void ChangeHairColorToRed()
    {
        if (HairHolder.transform.childCount > 0)
        {
            hairColourIndex = 5;
            ChangeHairColour(hairColourIndex);
        }
    }
    public void ChangeHairColorToWhite()
    {
        if (HairHolder.transform.childCount > 0)
        {
            hairColourIndex = 6;
            ChangeHairColour(hairColourIndex);
        }
    }

    private void ChangeHairColour(int colorIndex)
    {
        if(HairHolder.GetComponentInChildren<MeshRenderer>()!=null)
        {
            HairHolder.GetComponentInChildren<MeshRenderer>().material = CharSO.HairColor[colorIndex];
        }
        else
        {
            HairHolder.GetComponentInChildren<SkinnedMeshRenderer>().material = CharSO.HairColor[colorIndex];

        }
    }
    public void RestoreToDefault()
    {
        clotheIndex = 0;
        clotheColourIndex = 0;
        hairIndex = 0;
        hairColourIndex = 0;
        weaponIndex = 0;
        skinColor = 0;
        gender = 0;

        BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.BlackMaleBlackClothes[0];
        if (HairHolder.transform.childCount>0)
        {
            Destroy(HairHolder.transform.GetChild(0).gameObject);
        }

        ConfiguratorUIManager.Instance.UpdateClotheText(clotheIndex+1);
        ConfiguratorUIManager.Instance.UpdateHairText(hairIndex+1);

    }

}
