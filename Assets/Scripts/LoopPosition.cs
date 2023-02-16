using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopPosition : MonoBehaviour
{
    public GameObject V;
    int j = 0;
    void Move()
    {
        for (int i = 0; i < 100; i++)
        {
            float m = 1.0f * Time.deltaTime;
            V.transform.Translate(m, 0, 0);
            Debug.Log(V.transform.position.x);
        }
        Debug.Log("Цикл окончен");
    }

    void Update()
    {
        if (j >= 1)
        {
            V.transform.position = V.transform.position;
        }
        else
        {
            Move();
        }
        j++;
    }
}
