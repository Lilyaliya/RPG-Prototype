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
    [SerializeField] private float gravity = 0.08f;
    [SerializeField] private float jumpValue = 1.5f;
    [SerializeField] private float heightSit = 1.5f;
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
        if (Time.timeScale == 1f)
        {
            button_x = Input.GetAxis("Horizontal");
            button_z = Input.GetAxis("Vertical");
            if (player.isGrounded)
            {
                moveDir = new Vector3(button_x, 0f, button_z);
                moveDir = transform.TransformDirection(moveDir);
                if (Input.GetKey(KeyCode.Space))
                {
                    moveDir.y += jumpValue;
                }
                if (Input.GetKey(KeyCode.LeftControl))
                {
                    player.height = heightSit;
                }
                else
                    player.height = 2.0f;
            }
            moveDir.y -= gravity;
            //gameObject.transform.position += (moveDir*Time.deltaTime*speedValue);
            player.Move(moveDir * Time.deltaTime * speedValue);

        }
    }

}
