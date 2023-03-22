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
        if(item.itemType==Item.ItemType.Sword)
        {
            CharacterManager.Instance.isCharHoldingSword = true;
            CharacterManager.Instance.charCustomiser.EquipSword();
            return;
        }
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

    public void RemoveItem(Item.ItemType removedItemType, int removeAmount)
    {
        for(int i=0; i< itemList.Count; i++)
        {
            if (itemList[i].itemType == removedItemType)
            {
                if (itemList[i].amount < removeAmount)
                { return; }
                else
                {
                    itemList[i].amount -= removeAmount;
                    if (itemList[i].amount == 0)
                    {
                        itemList.Remove(itemList[i]);
                    }

                }
            }
        }
        UI_Inventory.Instance.RefreshInventoryItems();
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
