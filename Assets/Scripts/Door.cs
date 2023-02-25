using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    bool isOpened = true;
    [SerializeField] Animator anim;
   
    public void Open()
    {
        anim.SetBool("IsOpen", isOpened);
        isOpened = !isOpened;
    }
    public bool GetStatus()
    {
        return isOpened;
    }
}
