using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InGameUIManager : MonoBehaviour
{
    public TMP_Text interactionText;

    private void Update()
    {
        if(CameraRaycast.Instance.isHitCollectable)
        {
            interactionText.text = "[E] Click to Collect";
        }
        else if(CameraRaycast.Instance.isHitNPC)
        {
            interactionText.text = "[E] Click to Talk";
        }
        else
        {
            interactionText.text = "";
        }
    }
}
