using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopTiles : MonoBehaviour
{
    public Transform prefab;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 100; i++)
        {
            Instantiate(prefab, transform.position, transform.rotation);
            transform.Translate(i, 0, 0);
        }
    }

    
}
