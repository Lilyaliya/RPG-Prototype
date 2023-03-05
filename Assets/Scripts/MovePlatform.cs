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
    [HideInInspector] public bool activePlatform;
    BoxCollider _platform;
    bool _collision;
    RaycastHit aim;
    RaycastHit aimPrev;
    bool direction; // if true we move to the endPoint. Else to the startPoint
    void Start()
    {
        transform.position = startPoint.position;
        direction = true;
        _platform = GetComponent<BoxCollider>();
    }


    private void FixedUpdate()
    {
        if (direction)
        {
            MoveRight();
        }
        else
        {
            MoveLeft();
        }
        _collision = Physics.BoxCast(_platform.bounds.center, transform.GetChild(0).localScale, transform.up, out aim, transform.rotation, 0.2f);
        if (_collision)
        {
            //aim.collider.transform.parent = transform;
            aim.transform.parent = transform;
            activePlatform = true; // turns true if the player on this platform
            aimPrev = aim;
            //var t = aim.collider.gameObject.GetComponent<UseGravity>();
            //t.enabled = false;
            //Debug.Log(aim.collider.name);
        }
        else
        {
            if (aimPrev.collider && activePlatform)
                aimPrev.transform.parent = null;
            activePlatform = false;
        }
    }
    private void MoveLeft()
    {
        float step = speed * Time.deltaTime;
        var temp = Vector3.Magnitude(transform.position - startPoint.position);
        if (temp > step)
            transform.position = Vector3.MoveTowards(transform.position, startPoint.position, step);
        //if (transform.position.x > startPoint.position.x)
        //    transform.Translate(-step, 0, 0);
        else
            direction = true;
    }

    private void MoveRight()
    {
        float step = speed * Time.deltaTime;
        var temp = Vector3.Magnitude(transform.position - endPoint.position);
        if (temp > step)
            transform.position = Vector3.MoveTowards(transform.position, endPoint.position, step);

        //if (transform.position.x < endPoint.position.x)
        //    transform.Translate(step, 0, 0);
        else
            direction = false;
    }


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
            //Draw a Ray up from GameObject toward the maximum distance
            Gizmos.DrawRay(transform.position, transform.up * 0.2f);
            //Draw a cube at the maximum distance
            Gizmos.DrawWireCube(transform.position + transform.up * 0.2f, transform.GetChild(0).localScale);
        }
    }

}
