using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;

    [SerializeField] private float movementSpeed = 7f;

    [SerializeField] private float upSpeed = 10f;

    private float directionX = 0f;

    //Update is called once per frame
    void Update()
    {
        rb.AddForce(transform.up * upSpeed * Time.deltaTime);

        directionX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(directionX * movementSpeed, rb.velocity.y);
    }
} 
