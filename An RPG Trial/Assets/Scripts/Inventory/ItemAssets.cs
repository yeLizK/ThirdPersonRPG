using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAssets : MonoBehaviour
{
    private static ItemAssets _instance;
    public static ItemAssets Instance { get { return _instance; } }

    private void Awake()
    {
        if(_instance !=null && _instance != this)
        {
            Destroy(_instance);
        }
        else
        {
            _instance = this;
        }
    }

    public Sprite swordSprite;
    public Sprite healthPosition;
    public Sprite redFruit;
    public Sprite iron;
}
