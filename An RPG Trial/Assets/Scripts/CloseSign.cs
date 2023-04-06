using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseSign : MonoBehaviour
{
    public Collectable collectable;
    private bool isActive;

    private void Start()
    {
        isActive = true;
    }
    private void Update()
    {
        if(isActive)
        {
            if (collectable.isCollected)
            {
                gameObject.SetActive(false);
            }

        }
    }
}
