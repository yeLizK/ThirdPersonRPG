using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Inventory : MonoBehaviour
{
    private static UI_Inventory _instance;
    public static UI_Inventory Instance { get { return _instance; } }

    private void Awake()
    {
        if(_instance !=null && _instance !=this)
        {
            Destroy(_instance);
        }
        else { _instance = this; }
    }
    [SerializeField] private List<Transform> itemSlots;

    private GameObject ReturnEmptyItemSlot()
    {
        foreach(Transform slot in itemSlots)
        {
            if(slot.gameObject.activeSelf == false)
            {
                return slot.gameObject;
            }
        }
        return null;
    }

    private void EmptyInventory()
    {
        foreach(Transform slot in itemSlots)
        {
            slot.gameObject.SetActive(false);
        }
    }
    public void RefreshInventoryItems()
    {
        EmptyInventory();
        GameObject itemSlot;
        foreach(Item item in Inventory.Instance.GetItemList())
        {
            itemSlot = ReturnEmptyItemSlot();
            if(itemSlot !=null)
            {
                itemSlot.SetActive(true);
                itemSlot.GetComponent<Image>().sprite = item.GetSprite();
                itemSlot.GetComponentInChildren<TMP_Text>().text = item.amount.ToString();
            }
        }

    }
}
