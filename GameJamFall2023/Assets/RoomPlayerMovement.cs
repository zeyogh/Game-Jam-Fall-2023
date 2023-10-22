using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomPlayerMovement : MonoBehaviour
{

    public float moveSpeed = 5f;

    public Rigidbody2D rb;

    Vector2 movement;

    // Update is called once per frame
    void Update()
    {
       movement.x = Input.GetAxisRaw("Horizontal");//X Input
        movement.y = Input.GetAxisRaw("Vertical");//Y Input
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);//Movement
    }
}
