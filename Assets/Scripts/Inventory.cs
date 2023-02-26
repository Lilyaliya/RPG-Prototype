using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] List<GameObject> inventory;
    [SerializeField] int maxSize;
    public void Add(GameObject item)
    {
        if (inventory.Count < maxSize)
        {
            inventory.Add(item);
        }
        else
        {
            Debug.LogWarning("Ошибка! Инвентарь заполнен!");
        }
    }
    public List<GameObject> GetContent()
    {
        return inventory;
    }
    public void Pull(string name) // name cannot be repeated (at least in the scene)
    {
        var el = inventory.Find(el => el.name == name);
        if (el)
        {
            inventory.Remove(el);
        }
    }
}
