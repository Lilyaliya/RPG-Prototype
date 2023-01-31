using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float speed = 5f;
    private Transform position;
    void Start()
    {
        position = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        position.Rotate(0, speed * Time.deltaTime, 0);
    }
}
