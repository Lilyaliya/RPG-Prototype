using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    // Start is called before the first frame update
    private CharacterController player;
    private float button_x;
    private float button_z;
    private Vector3 moveDir;

    [SerializeField] private float speedValue = 5f;
    void Start()
    {
        player = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    void Move()
    {
        button_x = Input.GetAxis("Horizontal");
        button_z = Input.GetAxis("Vertical");
        if (player.isGrounded)
        {
            moveDir = new Vector3(button_x, 0f, button_z);
            moveDir = transform.TransformDirection(moveDir);
        }
        moveDir.y -= 1;
        //gameObject.transform.position += (moveDir*Time.deltaTime*speedValue);
        player.Move(moveDir * Time.deltaTime * speedValue);
    }

}
