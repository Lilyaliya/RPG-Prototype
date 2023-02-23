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
    BoxCollider _platform;
    bool _collision;
    RaycastHit aim;
    bool direction; // if true we move to the endPoint. Else to the startPoint
    void Start()
    {
        transform.position = startPoint.position;
        direction = true;
        _platform = GetComponent<BoxCollider>();
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
    private void FixedUpdate()
    {
        
        _collision = Physics.BoxCast(_platform.bounds.center, transform.GetChild(0).localScale, transform.up, out aim, transform.rotation, 0.1f);
        if (_collision)
        {
            //aim.collider.transform.parent = transform;
            aim.transform.parent = transform;
            var t = aim.collider.gameObject.GetComponent<UseGravity>();
            t.enabled = false;
            Debug.Log(aim.collider.name);
        }
        else if (aim.collider)
            aim.transform.parent = null;
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
   /* private void OnCollisionEnter(Collision collision)
    {
        //if (collision.gameObject.tag == "Player")
            collision.transform.parent = transform;
    }
    private void OnCollisionExit(Collision collision)
    {
        collision.transform.parent = null;
    }*/

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        //Check if there has been a hit yet
        if (_collision)
        {
            //Draw a Ray up from GameObject toward the hit
            Gizmos.DrawRay(transform.position, transform.up * aim.distance);
            //Draw a cube that extends to where the hit exists
            Gizmos.DrawWireCube(transform.position + transform.up * aim.distance, transform.GetChild(0).localScale);
        }
        //If there hasn't been a hit yet, draw the ray at the maximum distance
        else
        {
            //Draw a Ray forward from GameObject toward the maximum distance
            Gizmos.DrawRay(transform.position, transform.up * 0.1f);
            //Draw a cube at the maximum distance
            Gizmos.DrawWireCube(transform.position + transform.up * 0.1f, transform.GetChild(0).localScale);
        }
    }

}
