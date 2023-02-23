using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform startPoint;
    [SerializeField] Transform endPoint;
    [SerializeField] float speed = 1;
    bool direction; // if true we move to the endPoint. Else to the startPoint
    void Start()
    {
        transform.position = startPoint.position;
        direction = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (direction)
        {
            MoveRight();
        }
        else
        {
            MoveLeft();
        }
    }

    private void MoveLeft()
    {
        float step = speed * Time.deltaTime;
        if (transform.position.x > startPoint.position.x)
            transform.Translate(-step, 0, 0);
        else
            direction = true;
    }

    private void MoveRight()
    {
        float step = speed * Time.deltaTime;
        if (transform.position.x < endPoint.position.x)
            transform.Translate(step, 0, 0);
        else
            direction = false;
    }
}
