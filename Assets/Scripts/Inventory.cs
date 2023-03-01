using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField] List<GameObject> inventory;
    public GameObject selectedItem;
    [SerializeField] GameObject colouredArm;
    [SerializeField] int maxSize;
    [SerializeField] RectTransform element;
    [SerializeField] RectTransform content;
    public void Add(GameObject item)
    {
        if (inventory.Count < maxSize && !inventory.Find(el=> el.name == item.name))
        {
            
            inventory.Add(item);
            FillContent(item);
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
    void FillContent(GameObject item)
    {
        //RectTransform newEl = element;
        //newEl.GetComponentInChildren<Text>().text = name;
        //newEl.transform.parent = GameObject.FindWithTag("content").transform;
        /*foreach (Transform child in content)
        {
            Destroy(child.gameObject);
        }*/
        element.GetComponentInChildren<Text>().text = item.name;
        //element.GetComponent<Button>().onClick.AddListener(OnClick);
        element.GetComponent<Button>().onClick.AddListener(delegate { OnItemSelected(element.gameObject); });
        element.GetComponent<Image>().color = item.GetComponent<MeshRenderer>().material.color;
        var copy = Instantiate(element.gameObject) as GameObject;
        copy.transform.SetParent(content, false);
        copy.GetComponent<Button>().onClick.AddListener(delegate { OnItemSelected(copy.gameObject); });
        content.anchoredPosition = new Vector2(0, -content.rect.width / 2);
        //element.GetComponentInChildren<Text>().text = name;
        //Instantiate(element, GameObject.FindWithTag("content").transform);
    }
    public void OnItemSelected(GameObject item)
    {
        selectedItem = item;
        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        //selectedItem.GetComponent<Button>().onClick.AddListener(OnClick);
        colouredArm.GetComponent<MeshRenderer>().material.color = selectedItem.GetComponent<Image>().color;
        
    }
    public void OnClick()
    {

    }
    void RemoveComponent()
    {

    }
}
