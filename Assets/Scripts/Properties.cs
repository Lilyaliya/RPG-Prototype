using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Properties : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject V;
    public float X;
    public float Y;
    public float Z;
    bool rotateX=true;
    float rotationSpeed = 75.0f;
    void Start()
    {
        V.name = "Кубик";
        V.transform.position = new Vector3(X, Y, Z);
        V.transform.localScale = new Vector3(X, Y, Z);
        V.transform.Rotate(X, Y, Z, Space.Self);
        var t = V.GetComponent<Renderer>();
        t.material.color = Color.black;
    }


    /*
     *  X = 0.0f;
        Z = 0.0f;
        rotateX = true;
        rotationSpeed = 75.0f;
     */
    void FixedUpdate()
    {
        if (rotateX == true)
        {
            X += Time.deltaTime * rotationSpeed;

            if (X > 360.0f)
            {
                X = 0.0f;
                rotateX = false;
            }
        }
        else
        {
            Z += Time.deltaTime * rotationSpeed;

            if (Z > 360.0f)
            {
                Z = 0.0f;
                rotateX = true;
            }
        }

        transform.localRotation = Quaternion.Euler(X, 0, Z);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
