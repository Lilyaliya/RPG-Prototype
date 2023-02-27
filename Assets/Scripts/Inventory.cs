using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField] List<GameObject> inventory;
    [SerializeField] int maxSize;
    [SerializeField] Button element;
    public void Add(GameObject item)
    {
        if (inventory.Count < maxSize && !inventory.Find(el=> el.name == item.name))
        {
            inventory.Add(item);
            FillContent(item.name);
        }
        else if (inventory.Count >= maxSize)
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
    void FillContent(string name)
    {
        Button newEl = element;
        newEl.GetComponentInChildren<Text>().text = name;
        newEl.transform.parent = GameObject.FindWithTag("content").transform;
        //element.GetComponentInChildren<Text>().text = name;
        //Instantiate(element, GameObject.FindWithTag("content").transform);
    }
    void RemoveComponent()
    {

    }
}
