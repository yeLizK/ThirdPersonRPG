using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/CharacterCustomiserSO")]
public class CharacterCustomiserSO : ScriptableObject
{
    public Material[] BlackFemaleClothesList;
    public Material[] BlackMaleClothesList;

    public Material[] BrownFemaleClothesList;
    public Material[] BrownMaleClothesList;

    public Material[] WhiteFemaleClothesList;
    public Material[] WhiteMaleClothesList;

    public GameObject[] FemaleHair;
    public GameObject[] MaleHair;

    public GameObject[] Weapons;


}
