using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprint : MonoBehaviour
{

    private Rigidbody2D rb;
    public int baseSpeed;
    public int sprint;
    private int currentSpeed;
    private Vector3 movement = new Vector3(0f, 0f, 0f);

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    //  If the mentioned key is pressed down, have the player sprint
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed = baseSpeed + sprint;
        }
        else
        {
            currentSpeed = baseSpeed;
        }
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

    }

    void FixedUpdate()
    {
        rb.AddForce(movement * currentSpeed);
    }
}