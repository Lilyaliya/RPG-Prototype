using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPanel : MonoBehaviour
{
    public GameObject invMenu;
    bool isInv = false;
    // Start is called before the first frame update
    void Start()
    {
        invMenu.SetActive(false);
    }
    void ActivateCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    void DisableCursor()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
    }
    // Update is called once per frame
    void Update()
    {
        ActivateMenu();
    }

    private void ActivateMenu()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            isInv = !isInv;
        }
        if (isInv)
        {
            invMenu.SetActive(true);
            ActivateCursor();
        }
        else
        {
            invMenu.SetActive(false);
            DisableCursor();

        }
    }
}
