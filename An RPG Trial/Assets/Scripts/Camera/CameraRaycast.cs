using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRaycast : MonoBehaviour
{
    private static CameraRaycast _instance; 
    public static CameraRaycast Instance { get { return _instance; } }
    [HideInInspector] public Transform objectHit;

    //[HideInInspector]
    public bool isHitCollectable, isHitNPC;

    private float maxRayDistance = 3f;
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(_instance);
        }
        else
        {
            _instance = this;
        }
    }
    private void FixedUpdate()
    {
        RaycastHit hit;
        isHitCollectable = false;
        isHitNPC = false;
        if (Physics.Raycast(transform.position, transform.forward, out hit, maxRayDistance))
        {
            objectHit = hit.transform;
            if(objectHit.gameObject.tag.Equals("Collectable"))
            {
                isHitCollectable = true;
                isHitNPC = false;
            }
            else if(objectHit.gameObject.tag.Equals("NPC"))
            {
                isHitCollectable = false;
                isHitNPC = true;
            }
            else
            {
                isHitCollectable = false;
                isHitNPC = false;
            }
        }
    }
}
