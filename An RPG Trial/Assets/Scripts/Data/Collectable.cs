using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour , IDataPersistence
{
    [SerializeField] private string id;

    private bool isCollected;

    [ContextMenu("Generate guid for id")]
    private void GenerateGuid()
    {
        id = System.Guid.NewGuid().ToString();
    }

    public void LoadData(GameData data)
    {
        data.flowersCollected.TryGetValue(id, out isCollected);
        if(isCollected)
        {
            gameObject.SetActive(false);
        }
    }

    public void SaveData(ref GameData data)
    {
        if(data.flowersCollected.ContainsKey(id))
        {
            data.flowersCollected.Remove(id);
        }
        data.flowersCollected.Add(id, isCollected);
    }

    public void CollectObject()
    {
        isCollected = true;
        gameObject.SetActive(false);

    }
}
