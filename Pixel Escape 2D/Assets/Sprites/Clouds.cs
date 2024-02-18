using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clouds : MonoBehaviour
{
    public float moveSpeed;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(Vector2.left * moveSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        moveSpeed = -moveSpeed;
        rb.AddForce(Vector2.left * moveSpeed);
    }
}
