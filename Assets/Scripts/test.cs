using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    // Start is called before the first frame update

    public int  a;
    public string color;    // заданный цвет для куба
    public GameObject V;    // куб, у которого меняется цвет
    
    void Start()
    {
        var t = V.GetComponent<Renderer>();
        if (color == "red")
        {
            t.material.color = Color.red;
        }
        else if (color == "blue")
        {
            t.material.color = Color.blue;
        }
        else if (color == "black")
        {
            t.material.color = Color.black;
        }
        // и другие цвета ...
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
