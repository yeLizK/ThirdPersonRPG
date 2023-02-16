using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDialog : MonoBehaviour
{
    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;

    public TextAsset GetNPCDialog()
    {
        return inkJSON;
    }
}
