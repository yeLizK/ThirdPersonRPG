using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : IDataPersistence
{
    private static Inventory _instance = null;

    public static Inventory Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new Inventory();
            }
            return _instance;
        }
    }
    private List<Item> itemList;

    public Inventory()
    {
        itemList = new List<Item>();
    }

    public void LoadData(GameData data)
    {
        Item temp = null;
        foreach (var item in data.inventory)
        {
            temp.itemType = (Item.ItemType)System.Enum.Parse(typeof(Item.ItemType), item.Key);
            temp.amount = item.Value;
            AddItem(temp);
        }
        UI_Inventory.Instance.RefreshInventoryItems();
    }

    public void SaveData(ref GameData data)
    {
        foreach (Item item in itemList)
        {
            data.inventory.Add(item.itemType.ToString(), item.amount);
        }
    }
    public void AddItem(Item item)
    {
        foreach(Item listItem in itemList)
        {
            if (listItem.itemType == item.itemType)
            {
                listItem.amount++;
                return;
            }
        }
        itemList.Add(item);
        UI_Inventory.Instance.RefreshInventoryItems();
    }

    public bool RemoveItem(Item.ItemType removedItemType, int removeAmount)
    {
        foreach(Item listItem in itemList)
        {
            if (listItem.itemType == removedItemType)
            {
                if(listItem.amount<removeAmount)
                { return false; }
                else
                {
                    listItem.amount -= removeAmount;
                    if(listItem.amount==0)
                    {
                        itemList.Remove(listItem);
                    }
                    return true;
                }
            }
        }
        return false;
    }

    public List<Item> GetItemList()
    {
        return itemList;
    }

    public int ReturnItemAmount(Item.ItemType type)
    {
        foreach(Item item in itemList)
        {
            if(item.itemType == type)
            {
                return item.amount;
            }
        }
        return 0;
    }
    

}
