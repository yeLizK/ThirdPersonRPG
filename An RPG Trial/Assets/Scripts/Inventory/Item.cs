using UnityEngine;

[System.Serializable]
public class Item
{
    public enum ItemType {
        RedFruit,
        HealthPosion,
        Sword,
        Iron
    }

    public ItemType itemType;
    public int amount;

    public Sprite GetSprite()
    {
        switch (itemType)
        {
            default:
            case ItemType.Sword: return ItemAssets.Instance.swordSprite;
            case ItemType.Iron: return ItemAssets.Instance.iron;
            case ItemType.RedFruit: return ItemAssets.Instance.redFruit;
            case ItemType.HealthPosion: return ItemAssets.Instance.healthPosition;
        }
    }
}
