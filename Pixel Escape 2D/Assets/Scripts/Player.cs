﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private float moveSpeed;
    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;
    public Sprite injuredPigSprite;
    public Sprite healthyPigSprite;
    public GameManager GameManager;
    public UIManager UIManager;

    int health = 3;

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = PlayerPrefs.GetFloat(CommonConstants.playerMovementSensitivity);
        Debug.Log("moveSpeed:" + moveSpeed);
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = healthyPigSprite;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0)){
            Vector3 touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if(touchPos.x < 0)
            {
                rb.AddForce(Vector2.left * moveSpeed);
            }
            else
            {
                rb.AddForce(Vector2.right * moveSpeed);
            }
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == CommonConstants.blockTag)
        {
            health--;
            UIManager.decreaseHealth(health);
            if (health == 0)
            {
                spriteRenderer.sprite = injuredPigSprite;
                GameManager.GameOver();
            }
            else
            {
                Destroy(collision.gameObject);
            }
        }
    }
}
