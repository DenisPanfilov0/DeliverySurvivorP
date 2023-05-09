using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;

    public List<GameObject> inventoryItems = new List<GameObject>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddItem(GameObject item)
    {
        inventoryItems.Add(item);
    }

    public void RemoveItem(GameObject item)
    {
        inventoryItems.Remove(item);
    }

}