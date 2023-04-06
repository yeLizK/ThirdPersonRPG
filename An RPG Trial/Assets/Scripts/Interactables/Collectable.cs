using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public Item.ItemType itemType;
    public bool isCollected;

    [SerializeField] private GameObject objectBeforeCollection, objectAfterCollection;

    public void CollectObject()
    {
        Item item = new Item { itemType = itemType, amount = 1 };
        isCollected = true;
        Destroy(gameObject.GetComponent<BoxCollider>());
        CharacterManager.Instance.Inventory.AddItem(item);
        UI_Inventory.Instance.RefreshInventoryItems();
        objectBeforeCollection.SetActive(false);
        if(objectAfterCollection !=null)
        {
            objectAfterCollection.SetActive(true);
        }
        PlayerInteraction.Instance.isCharInCollectableRange = false;
        InGameUIManager.Instance.CloseInteractionText();
    }
}
