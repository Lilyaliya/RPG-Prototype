using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loop_1 : MonoBehaviour
{
    int i = 0;
    // Start is called before the first frame update
    void Start()
    {

        while (i > 0)
        {
            Debug.Log("Число i = " + i.ToString());
            i++;
            if (i >= 100)
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
