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
    private int hairIndex;
    private int weaponIndex;

    [SerializeField] private CharacterCustomiserSO CharSO;

    [SerializeField] private GameObject BaseHolder, HeadHolder, RightArmHolder;


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
        hairIndex = 0;
        weaponIndex = 0;
        skincolor = 0;
        gender = 0;
    }

    public void SelectFemale()
    {
        if(skincolor == 0)
        {
            if (clothIndex >= CharSO.BlackFemaleClothesList.Length)
            {
                clothIndex = 0;
            }
            BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.BlackFemaleClothesList[clothIndex];
        }else if(skincolor ==1)
        {
            if (clothIndex >= CharSO.BrownFemaleClothesList.Length)
            {
                clothIndex = 0;
            }
            BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.BrownFemaleClothesList[clothIndex];
        }else if(skincolor ==2)
        {
            if (clothIndex >= CharSO.WhiteFemaleClothesList.Length)
            {
                clothIndex = 0;
            }
            BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.WhiteFemaleClothesList[clothIndex];
        }
        gender = 0;
    }

    public void SelectMale()
    {
        if (skincolor == 0)
        {
            if (clothIndex >= CharSO.BlackMaleClothesList.Length)
            {
                clothIndex = 0;
            }
            BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.BlackMaleClothesList[clothIndex];
        }
        else if (skincolor == 1)
        {
            if (clothIndex >= CharSO.BrownMaleClothesList.Length)
            {
                clothIndex = 0;
            }
            BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.BrownMaleClothesList[clothIndex];
        }
        else if (skincolor == 2)
        {
            if (clothIndex >= CharSO.WhiteMaleClothesList.Length)
            {
                clothIndex = 0;
            }
            BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.WhiteMaleClothesList[clothIndex];
        }
        gender = 1;
    }

    public void ChangeSkinColorToBlack()
    {
        if (gender == 0)
        {
            BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.BlackFemaleClothesList[clothIndex];
        }
        else if (gender == 1)
        {
            BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.BlackMaleClothesList[clothIndex];
        }
        skincolor = 0;
    }

    public void ChangeSkinColorToBrown()
    {
        if (gender == 0)
        {
            BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.BrownFemaleClothesList[clothIndex];
        }
        else if (gender == 1)
        {
            BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.BrownMaleClothesList[clothIndex];
        }
        skincolor = 1;
    }    

    public void ChangeSkinColorToWhite()
    {
        if (gender == 0)
        {
            BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.WhiteFemaleClothesList[clothIndex];
        }
        else if (gender == 1)
        {
            BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.WhiteMaleClothesList[clothIndex];
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
                if (clothIndex >= CharSO.BlackFemaleClothesList.Length)
                {
                    clothIndex = 0;
                }
                BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.BlackFemaleClothesList[clothIndex];

            }else if(skincolor==1)
            {
                if (clothIndex >= CharSO.BrownFemaleClothesList.Length)
                {
                    clothIndex = 0;
                }
                BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.BrownFemaleClothesList[clothIndex];
            }else if (skincolor == 2)
            {
                if (clothIndex >= CharSO.WhiteFemaleClothesList.Length)
                {
                    clothIndex = 0;
                }
                BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.WhiteFemaleClothesList[clothIndex];
            }
        }
        else if (gender == 1)
        {
            if (skincolor == 0)
            {
                if (clothIndex >= CharSO.BlackMaleClothesList.Length)
                {
                    clothIndex = 0;
                }
                BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.BlackMaleClothesList[clothIndex];

            }
            else if (skincolor == 1)
            {
                if (clothIndex >= CharSO.BrownMaleClothesList.Length)
                {
                    clothIndex = 0;
                }
                BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.BrownMaleClothesList[clothIndex];
            }
            else if (skincolor == 2)
            {
                if (clothIndex >= CharSO.WhiteMaleClothesList.Length)
                {
                    clothIndex = 0;
                }
                BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.WhiteMaleClothesList[clothIndex];
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
                    clothIndex = CharSO.BlackFemaleClothesList.Length - 1;
                }
                BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.BlackFemaleClothesList[clothIndex];

            }
            else if (skincolor == 1)
            {
                if (clothIndex < 0)
                {
                    clothIndex = CharSO.BrownFemaleClothesList.Length - 1;
                }
                BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.BrownFemaleClothesList[clothIndex];
            }
            else if (skincolor == 2)
            {
                if (clothIndex < 0)
                {
                    clothIndex = CharSO.WhiteFemaleClothesList.Length - 1;
                }
                BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.WhiteFemaleClothesList[clothIndex];
            }
        }
        else if (gender == 1)
        {
            if (skincolor == 0)
            {
                if (clothIndex < 0)
                {
                    clothIndex = CharSO.BlackMaleClothesList.Length - 1;
                }
                BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.BlackMaleClothesList[clothIndex];

            }
            else if (skincolor == 1)
            {
                if (clothIndex < 0)
                {
                    clothIndex = CharSO.BrownMaleClothesList.Length - 1;
                }
                BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.BrownMaleClothesList[clothIndex];
            }
            else if (skincolor == 2)
            {
                if (clothIndex < 0)
                {
                    clothIndex = CharSO.WhiteMaleClothesList.Length - 1;
                }
                BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.WhiteMaleClothesList[clothIndex];
            }
        }
    }

    public void ChangeHairRightSelection()
    {
        hairIndex++;
        if (gender==0)
        {
            if (hairIndex >= CharSO.FemaleHair.Length)
            {
                hairIndex = 0;
            }
            InstantiateFemaleHair();

        }else if(gender==1)
        {
            if (hairIndex >= CharSO.MaleHair.Length)
            {
                hairIndex = 0;
            }
            InstantiateMaleHair();
        }
    }
    public void ChangeHairLeftSelection()
    {
        hairIndex--;
        if (gender == 0)
        {
            if (hairIndex < 0)
            {
                hairIndex = CharSO.FemaleHair.Length-1;
            }
            InstantiateFemaleHair();
        }
        else if (gender == 1)
        {
            if (hairIndex < 0)
            {
                hairIndex = CharSO.MaleHair.Length-1;
            }
            InstantiateMaleHair();
        }
    }

    private void InstantiateFemaleHair()
    {
        GameObject tempHair;
        if (HeadHolder.transform.childCount > 0)
        {
            foreach (Transform child in HeadHolder.GetComponentsInChildren<Transform>())
            {
                if (child.gameObject != HeadHolder) Destroy(child.gameObject);
            }
        }
        tempHair = Instantiate(CharSO.FemaleHair[hairIndex], HeadHolder.transform);
        tempHair.transform.parent = HeadHolder.transform;
    }

    private void InstantiateMaleHair()
    {
        GameObject tempHair;
        if (HeadHolder.transform.childCount>0)
        {
            foreach(Transform child in HeadHolder.GetComponentsInChildren<Transform>())
            {
                if(child.gameObject!=HeadHolder) Destroy(child.gameObject); 
                
            }
        }
        tempHair = Instantiate(CharSO.MaleHair[hairIndex],HeadHolder.transform);
        tempHair.transform.parent = HeadHolder.transform;

    }
    
    public void ChangeWeaponRightSelection()
    {

    }

    public void RestoreToDefault()
    {
        if(gender == 0)
        {
            if (skincolor ==0)
            {
                BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.BlackFemaleClothesList[0];       
            }
            else if (skincolor == 1)
            {
                BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.BrownFemaleClothesList[0];

            }
            else if (skincolor == 2)
            {
                BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.WhiteFemaleClothesList[0];

            }
            InstantiateFemaleHair();

        }
        else if(gender == 1)
        {
            if(skincolor == 0)
            {
                BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.BlackMaleClothesList[0];
            }
            else if(skincolor == 1)
            {
                BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.BrownMaleClothesList[0];

            }
            else if(skincolor ==2)
            {
                BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.WhiteMaleClothesList[0];
            }
            InstantiateMaleHair();
        }

        GameObject tempWeapon = Instantiate(CharSO.Weapons[0]);
        if(tempWeapon == null)
        {
            Destroy(RightArmHolder.transform.GetChild(0));
        }
        tempWeapon.transform.parent = RightArmHolder.transform;
    }

}
