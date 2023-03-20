using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public Item.ItemType itemType;
    [SerializeField] private UI_Inventory uiInventory;

    [SerializeField] private string id;

    private bool isCollected;

    [SerializeField] private GameObject objectBeforeCollection, objectAfterCollection;

    [ContextMenu("Generate guid for id")]
    private void GenerateGuid()
    {
        id = System.Guid.NewGuid().ToString();
    }

    public void CollectObject()
    {
        Item item = new Item { itemType = itemType, amount = 1 };
        isCollected = true;
        Destroy(gameObject.GetComponent<BoxCollider>());
        Inventory.Instance.AddItem(item);
        uiInventory.RefreshInventoryItems();
        objectBeforeCollection.SetActive(false);
        objectAfterCollection.SetActive(true);
        PlayerInteraction.Instance.isCharInCollectableRange = false;
        InGameUIManager.Instance.CloseInteractionText();
    }
}
