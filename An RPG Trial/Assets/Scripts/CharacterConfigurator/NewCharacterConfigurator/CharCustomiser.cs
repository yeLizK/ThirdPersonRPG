using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharCustomiser : MonoBehaviour
{
    private static CharCustomiser _instance;
    public static CharCustomiser Instance { get { return _instance; } }

    private int gender; //0-female 0-male
    private int skincolor; // 0-black, 1-brown, 2-white

    private int clothIndex;
    private int clotheColourIndex;
    private int hairIndex;
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
        clothIndex = 0;
        clotheColourIndex = 0;
        hairIndex = 0;
        hairColourIndex = 0;
        weaponIndex = 0;
        skincolor = 0;
        gender = 0;
    }

    private void ChangeBlackFemaleClothes(int colorIndex)
    {
        if (colorIndex == 0)
        {
            BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.BlackFemaleBlackClothes[clothIndex];
        }
        else if (colorIndex == 1)
        {
            BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.BlackFemaleBlueClothes[clothIndex];
        }
        else if (colorIndex == 2)
        {
            BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.BlackFemaleCyanClothes[clothIndex];
        }
        else if (colorIndex == 3)
        {
            BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.BlackFemalePurpleClothes[clothIndex];
        }
        else if (colorIndex == 4)
        {
            BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.BlackFemaleWhiteClothes[clothIndex];
        }
    }

    private void ChangeBrownFemaleClothes(int colorIndex)
    {
        if (colorIndex == 0)
        {
            BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.BrownFemaleBlackClothes[clothIndex];
        }
        else if (colorIndex == 1)
        {
            BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.BrownFemaleBlueClothes[clothIndex];
        }
        else if (colorIndex == 2)
        {
            BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.BrownFemaleCyanClothes[clothIndex];
        }
        else if (colorIndex == 3)
        {
            BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.BrownFemalePurpleClothes[clothIndex];
        }
        else if (colorIndex == 4)
        {
            BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.BrownFemaleWhiteClothes[clothIndex];
        }
    }

    private void ChangeWhiteFemaleClothes(int colorIndex)
    {
        if (colorIndex == 0)
        {
            BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.WhiteFemaleBlackClothes[clothIndex];
        }
        else if (colorIndex == 1)
        {
            BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.WhiteFemaleBlueClothes[clothIndex];
        }
        else if (colorIndex == 2)
        {
            BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.WhiteFemaleCyanClothes[clothIndex];
        }
        else if (colorIndex == 3)
        {
            BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.WhiteFemalePurpleClothes[clothIndex];
        }
        else if (colorIndex == 4)
        {
            BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.WhiteFemaleWhiteClothes[clothIndex];
        }
    }

    private void ChangeBlackMaleClothes(int colorIndex)
    {
        if (colorIndex == 0)
        {
            BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.BlackMaleBlackClothes[clothIndex];
        }
        else if (colorIndex == 1)
        {
            BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.BlackMaleBlueClothes[clothIndex];
        }
        else if (colorIndex == 2)
        {
            BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.BlackMaleCyanClothes[clothIndex];
        }
        else if (colorIndex == 3)
        {
            BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.BlackMalePurpleClothes[clothIndex];
        }
        else if (colorIndex == 4)
        {
            BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.BlackMaleWhiteClothes[clothIndex];
        }
    }

    private void ChangeBrownMaleClothes(int colorIndex)
    {
        if (clotheColourIndex == 0)
        {
            BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.BrownMaleBlackClothes[clothIndex];
        }
        else if (clotheColourIndex == 1)
        {
            BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.BrownMaleBlueClothes[clothIndex];
        }
        else if (clotheColourIndex == 2)
        {
            BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.BrownMaleCyanClothes[clothIndex];
        }
        else if (clotheColourIndex == 3)
        {
            BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.BrownMalePurpleClothes[clothIndex];
        }
        else if (clotheColourIndex == 4)
        {
            BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.BrownMaleWhiteClothes[clothIndex];
        }
    }

    private void ChangeWhiteMaleClothes(int colorIndex)
    {
        if (clotheColourIndex == 0)
        {
            BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.WhiteMaleBlackClothes[clothIndex];
        }
        else if (clotheColourIndex == 1)
        {
            BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.WhiteMaleBlueClothes[clothIndex];
        }
        else if (clotheColourIndex == 2)
        {
            BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.WhiteMaleCyanClothes[clothIndex];
        }
        else if (clotheColourIndex == 3)
        {
            BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.WhiteMalePurpleClothes[clothIndex];
        }
        else if (clotheColourIndex == 4)
        {
            BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.WhiteMaleWhiteClothes[clothIndex];
        }
    }
    public void SelectFemale()
    {
        if(skincolor == 0)
        {
            if (clothIndex >= CharSO.BlackFemaleBlackClothes.Length)
            {
                clothIndex = 0;
            }
            ChangeBlackFemaleClothes(clotheColourIndex);
        }
        else if(skincolor ==1)
        {
            if (clothIndex >= CharSO.BrownFemaleBlackClothes.Length)
            {
                clothIndex = 0;
            }
            ChangeBrownFemaleClothes(clotheColourIndex);
        }
        else if(skincolor ==2)
        {
            if (clothIndex >= CharSO.WhiteFemaleBlackClothes.Length)
            {
                clothIndex = 0;
            }
            ChangeWhiteFemaleClothes(clotheColourIndex);
        }
        gender = 0;
    }

    public void SelectMale()
    {
        if (skincolor == 0)
        {
            if (clothIndex >= CharSO.BlackMaleBlackClothes.Length)
            {
                clothIndex = 0;
            }
            ChangeBlackMaleClothes(clotheColourIndex);
        }
        else if (skincolor == 1)
        {
            if (clothIndex >= CharSO.BrownMaleBlackClothes.Length)
            {
                clothIndex = 0;
            }
            ChangeBrownMaleClothes(clotheColourIndex);
        }
        else if (skincolor == 2)
        {
            if (clothIndex >= CharSO.WhiteFemaleBlackClothes.Length)
            {
                clothIndex = 0;
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
        skincolor = 0;
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
        skincolor = 1;
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
        skincolor = 2;
    }

    public void ChangeClothingRightSelection()
    {
        clothIndex++;
        if(gender==0)
        {
            if(skincolor==0)
            {
                if (clothIndex >= CharSO.BlackFemaleBlackClothes.Length)
                {
                    clothIndex = 0;
                }
                ChangeBlackFemaleClothes(clotheColourIndex);

            }else if(skincolor==1)
            {
                if (clothIndex >= CharSO.BrownFemaleBlackClothes.Length)
                {
                    clothIndex = 0;
                }
                ChangeBlackFemaleClothes(clotheColourIndex);
            }
            else if (skincolor == 2)
            {
                if (clothIndex >= CharSO.WhiteFemaleBlackClothes.Length)
                {
                    clothIndex = 0;
                }
                ChangeWhiteFemaleClothes(clotheColourIndex);

            }
        }
        else if (gender == 1)
        {
            if (skincolor == 0)
            {
                if (clothIndex >= CharSO.BlackMaleBlackClothes.Length)
                {
                    clothIndex = 0;
                }
                ChangeBlackMaleClothes(clotheColourIndex);

            }
            else if (skincolor == 1)
            {
                if (clothIndex >= CharSO.BrownMaleBlackClothes.Length)
                {
                    clothIndex = 0;
                }
                ChangeBlackMaleClothes(clotheColourIndex);
            }
            else if (skincolor == 2)
            {
                if (clothIndex >= CharSO.WhiteMaleBlackClothes.Length)
                {
                    clothIndex = 0;
                }
                ChangeWhiteMaleClothes(clotheColourIndex);
            }
        }
    }

    public void ChangeClothingLeftSelection()
    {
        clothIndex--;
        if (gender == 0)
        {
            if (skincolor == 0)
            {
                if (clothIndex <0)
                {
                    clothIndex = CharSO.BlackFemaleBlackClothes.Length - 1;
                }
                ChangeBlackFemaleClothes(clotheColourIndex);
            }
            else if (skincolor == 1)
            {
                if (clothIndex < 0)
                {
                    clothIndex = CharSO.BrownFemaleBlackClothes.Length - 1;
                }
                ChangeBrownFemaleClothes(clotheColourIndex);
            }
            else if (skincolor == 2)
            {
                if (clothIndex < 0)
                {
                    clothIndex = CharSO.WhiteFemaleBlackClothes.Length - 1;
                }
                ChangeWhiteFemaleClothes(clotheColourIndex);
            }
        }
        else if (gender == 1)
        {
            if (skincolor == 0)
            {
                if (clothIndex < 0)
                {
                    clothIndex = CharSO.BlackMaleBlackClothes.Length - 1;
                }
                ChangeBlackMaleClothes(clotheColourIndex);
            }
            else if (skincolor == 1)
            {
                if (clothIndex < 0)
                {
                    clothIndex = CharSO.BrownMaleBlackClothes.Length - 1;
                }
                ChangeBrownMaleClothes(clotheColourIndex);
            }
            else if (skincolor == 2)
            {
                if (clothIndex < 0)
                {
                    clothIndex = CharSO.WhiteMaleBlackClothes.Length - 1;
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

    public void RestoreToDefault()
    {
        if(gender == 0)
        {
            if (skincolor ==0)
            {
                BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.BlackFemaleBlackClothes[0];       
            }
            else if (skincolor == 1)
            {
                BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.BrownFemaleBlackClothes[0];

            }
            else if (skincolor == 2)
            {
                BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.WhiteFemaleBlackClothes[0];

            }
            InstantiateHair(0);

        }
        else if(gender == 1)
        {
            if(skincolor == 0)
            {
                BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.BlackMaleBlackClothes[0];
            }
            else if(skincolor == 1)
            {
                BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.BrownMaleBlackClothes[0];

            }
            else if(skincolor ==2)
            {
                BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.WhiteMaleBlackClothes[0];
            }
            InstantiateHair(0);
        }
    }

    public void ChangeClotheColorToBlack()
    {
        if(gender == 0)
        {
            if(skincolor==0)
            {
                BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.BlackFemaleBlackClothes[clothIndex];
            }else if(skincolor==1)
            {
                BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.BrownFemaleBlackClothes[clothIndex];
            }
            else if (skincolor == 2)
            {
                BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.WhiteFemaleBlackClothes[clothIndex];
            }
        }else if(gender == 1)
        {
            if (skincolor == 0)
            {
                BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.BlackMaleBlackClothes[clothIndex];
            }
            else if (skincolor == 1)
            {
                BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.BrownMaleBlackClothes[clothIndex];
            }
            else if (skincolor == 2)
            {
                BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.WhiteMaleBlackClothes[clothIndex];
            }
        }
        clotheColourIndex = 0;
    }

    public void ChangeClotheColorToBlue()
    {
        if (gender == 0)
        {
            if (skincolor == 0)
            {
                BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.BlackFemaleBlueClothes[clothIndex];
            }
            else if (skincolor == 1)
            {
                BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.BrownFemaleBlueClothes[clothIndex];
            }
            else if (skincolor == 2)
            {
                BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.WhiteFemaleBlueClothes[clothIndex];
            }
        }
        else if (gender == 1)
        {
            if (skincolor == 0)
            {
                BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.BlackMaleBlueClothes[clothIndex];
            }
            else if (skincolor == 1)
            {
                BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.BrownMaleBlueClothes[clothIndex];
            }
            else if (skincolor == 2)
            {
                BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.WhiteMaleBlueClothes[clothIndex];
            }
        }
        clotheColourIndex = 1;

    }

    public void ChangeClotheColorToCyan()
    {
        if (gender == 0)
        {
            if (skincolor == 0)
            {
                BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.BlackFemaleCyanClothes[clothIndex];
            }
            else if (skincolor == 1)
            {
                BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.BrownFemaleCyanClothes[clothIndex];
            }
            else if (skincolor == 2)
            {
                BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.WhiteFemaleCyanClothes[clothIndex];
            }
        }
        else if (gender == 1)
        {
            if (skincolor == 0)
            {
                BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.BlackMaleCyanClothes[clothIndex];
            }
            else if (skincolor == 1)
            {
                BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.BrownMaleCyanClothes[clothIndex];
            }
            else if (skincolor == 2)
            {
                BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.WhiteMaleCyanClothes[clothIndex];
            }
        }
        clotheColourIndex = 2;

    }

    public void ChangeClotheColorToPurple()
    {
        if (gender == 0)
        {
            if (skincolor == 0)
            {
                BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.BlackFemalePurpleClothes[clothIndex];
            }
            else if (skincolor == 1)
            {
                BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.BrownFemalePurpleClothes[clothIndex];
            }
            else if (skincolor == 2)
            {
                BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.WhiteFemalePurpleClothes[clothIndex];
            }
        }
        else if (gender == 1)
        {
            if (skincolor == 0)
            {
                BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.BlackMalePurpleClothes[clothIndex];
            }
            else if (skincolor == 1)
            {
                BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.BrownMalePurpleClothes[clothIndex];
            }
            else if (skincolor == 2)
            {
                BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.WhiteMalePurpleClothes[clothIndex];
            }
        }
        clotheColourIndex = 3;

    }

    public void ChangeClotheColorToWhite()
    {
        if (gender == 0)
        {
            if (skincolor == 0)
            {
                BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.BlackFemaleWhiteClothes[clothIndex];
            }
            else if (skincolor == 1)
            {
                BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.BrownFemaleWhiteClothes[clothIndex];
            }
            else if (skincolor == 2)
            {
                BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.WhiteFemaleWhiteClothes[clothIndex];
            }
        }
        else if (gender == 1)
        {
            if (skincolor == 0)
            {
                BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.BlackMaleWhiteClothes[clothIndex];
            }
            else if (skincolor == 1)
            {
                BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.BrownMaleWhiteClothes[clothIndex];
            }
            else if (skincolor == 2)
            {
                BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.WhiteMaleWhiteClothes[clothIndex];
            }
        }
        clotheColourIndex = 4;

    }

    public void ChangeHairColorToBlack()
    {
        hairColourIndex = 0;
        ChangeHairColour(hairColourIndex);
    }

    public void ChangeHairColorToYellow()
    {
        hairColourIndex = 1;
        ChangeHairColour(hairColourIndex);

    }
    public void ChangeHairColorToBrown()
    {
        hairColourIndex = 2;
        ChangeHairColour(hairColourIndex);

    }
    public void ChangeHairColorToCyan()
    {
        hairColourIndex = 3;
        ChangeHairColour(hairColourIndex);

    }
    public void ChangeHairColorToPurple()
    {
        hairColourIndex = 4;
        ChangeHairColour(hairColourIndex);
    }
    public void ChangeHairColorToRed()
    {
        hairColourIndex = 5;
        ChangeHairColour(hairColourIndex);
    }
    public void ChangeHairColorToWhite()
    {
        hairColourIndex = 6;
        ChangeHairColour(hairColourIndex);
    }

    private void ChangeHairColour(int colorIndex)
    {
        HairHolder.GetComponentInChildren<MeshRenderer>().material = CharSO.HairColor[colorIndex];

    }
}
