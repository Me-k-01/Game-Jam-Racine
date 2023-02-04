using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public Rigidbody playerDemo;
    public float moveForce = 0.01f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //rb.constraints = RigidbodyConstraints.FreezePosition;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            playerDemo.velocity = new Vector3(-moveForce, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            playerDemo.velocity = new Vector3(moveForce, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            playerDemo.velocity = new Vector3(0f, moveForce, 0f);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            playerDemo.velocity = new Vector3(0f, -moveForce, 0f);

        }
    }
}
