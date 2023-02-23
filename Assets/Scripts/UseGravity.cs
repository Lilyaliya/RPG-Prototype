using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseGravity : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float step = 2.0f * Time.deltaTime;
        transform.Translate(0, -step, 0);
    }
}
