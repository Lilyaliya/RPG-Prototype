using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colored : MonoBehaviour
{
    [SerializeField] GameObject[] colors;
    private void Start()
    {
        foreach (var el in colors)
        {
            el.tag = "Color";
        }
    }
}
