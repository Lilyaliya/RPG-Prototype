using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField] List<GameObject> inventory;
    [SerializeField] int maxSize;
    [SerializeField] RectTransform element;
    [SerializeField] RectTransform content;
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
        //RectTransform newEl = element;
        //newEl.GetComponentInChildren<Text>().text = name;
        //newEl.transform.parent = GameObject.FindWithTag("content").transform;
        /*foreach (Transform child in content)
        {
            Destroy(child.gameObject);
        }*/
        element.GetComponentInChildren<Text>().text = name;
        var copy = Instantiate(element.gameObject) as GameObject;
        copy.transform.SetParent(content, false);
        content.anchoredPosition = new Vector2(0, -content.rect.width / 2);
        //element.GetComponentInChildren<Text>().text = name;
        //Instantiate(element, GameObject.FindWithTag("content").transform);
    }
    void RemoveComponent()
    {

    }
}
