using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactive : MonoBehaviour
{
    Camera cam;
    Ray ray;
    RaycastHit obj;
    [SerializeField] float maxDistance;
    [SerializeField] KeyCode onDrawButton;
    [SerializeField] Text text;
    private void Start()
    {
        cam = Camera.main;
    }
    private void Update()
    {
        Ray();
        Interact();
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
            text.enabled = true;
        }
        if (obj.transform==null)
        {
            Debug.DrawRay(ray.origin, ray.direction, color: Color.red);
            text.enabled = false;
        }
    }

    void Interact()
    {
        if (obj.transform != null && obj.transform.GetComponent<Door>())
        {
            if (obj.transform.GetComponent<Door>().GetStatus())
                text.text = "Œ“ –€“‹ (K)";
            else
                text.text = "«¿ –€“‹ (K)";
            if (Input.GetKeyDown(KeyCode.K))
            {
                obj.transform.GetComponent<Door>().Open();
            }
        }
        else if (obj.transform != null && obj.collider.gameObject.tag == "Color") // we can take a color to the inventory
        {
            text.text = "¬«ﬂ“‹ (Q)";
            if (Input.GetKeyDown(KeyCode.Q))
            {
                gameObject.GetComponent<Inventory>().Add(obj.collider.gameObject);
            }
        }
        else if (obj.transform != null && obj.collider.gameObject.tag != "mechanism" && obj.collider.gameObject.tag != "Ground")
        {
            text.text = "œŒ –¿—»“‹ "+ onDrawButton.ToString();
            if (Input.GetKeyDown(onDrawButton))
            {
                obj.collider.gameObject.GetComponent<MeshRenderer>().material.color = GameObject.FindGameObjectWithTag("Arm").GetComponent<MeshRenderer>().material.color;
            }
        }
    }
}
