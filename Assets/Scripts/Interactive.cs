using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactive : MonoBehaviour
{
    [SerializeField] Camera cam;
    Ray ray;
    RaycastHit obj;
    [SerializeField] float maxDistance;
    private void Start()
    {
        cam = Camera.main;
    }
    private void Update()
    {
        Ray();
        TestRay();
    }

    void Ray()
    {
        ray = cam.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));

    }
    void TestRay()
    {
        if (Physics.Raycast(ray,out obj, maxDistance))
        {
            Debug.DrawRay(ray.origin, ray.direction*maxDistance, color: Color.blue);
        }
        if (obj.transform==null)
        {
            Debug.DrawRay(ray.origin, ray.direction, color: Color.red);
        }
    }
}
