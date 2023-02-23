using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/FemaleKnightSO")]
public class FemaleKnightSO : ScriptableObject
{
    public Material[] Materials;

    public Mesh[] SkinMesh;

    public Mesh[] EyebrowsMesh;

    public Mesh[] HeadArmorMesh;

    public Mesh[] TorsoMesh;

    public Mesh[] ArmUpperRightMesh;

    public Mesh[] ArmUpperLeftMesh;

    public Mesh[] ArmLowerRightMesh;

    public Mesh[] ArmLowerLeftMesh;

    public Mesh[] RightHandMesh;

    public Mesh[] LeftHandMesh;

    public Mesh[] HipsMesh;

    public Mesh[] LegRightMesh;

    public Mesh[] LegLeftMesh;

    public Mesh[] HairMesh;
}
