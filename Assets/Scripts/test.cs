using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    // Start is called before the first frame update

    public int  a;
    
    void Start()
    {
        a = 9;
        if (a >= 10 && a++ <= 99)
        {
            Debug.Log("Двузначное число");
        }
        Debug.Log(a);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
