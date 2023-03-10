using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    private Camera cam;
    private float mouseX;
    private float mouseY;
    
    public float Sensitivity = 5f;
    private float smoothTime = 0.1f;
    private float CurVelosityX;
    private float CurVelosityY;
    private float mouseXCurr;
    private float mouseYCurr;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
        cam = Camera.main;
        
    }
    
    // Update is called once per frame
    void Update()
    {
        NewMethod();

    }

    private void NewMethod()
    {
        if (Time.timeScale == 1f)
        {
            mouseX += Input.GetAxis("Mouse X") * Sensitivity;
            mouseY += Input.GetAxis("Mouse Y") * Sensitivity;

            mouseXCurr = Mathf.SmoothDamp(mouseX, mouseXCurr, ref CurVelosityX, smoothTime);
            mouseYCurr = Mathf.SmoothDamp(mouseY, mouseYCurr, ref CurVelosityY, smoothTime);

            //mouseXCurr = Mathf.Clamp(mouseXCurr, -8f, 80f);
            mouseYCurr = Mathf.Clamp(mouseYCurr, -50f, 50f);

            cam.transform.rotation = Quaternion.Euler(-mouseYCurr, mouseXCurr, 0f);
            gameObject.transform.rotation = Quaternion.Euler(0f, mouseXCurr, 0.0001f);

        }
    }
}
