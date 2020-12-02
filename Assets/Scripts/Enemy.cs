using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Enemy : MonoBehaviour
{
    public EnemyData enemyData;
    public SpriteRenderer spriteRenderer;
    private float horizontalSpeed;
    private float verticalSpeed;
    private Rigidbody2D rigidBody2D;
    public void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidBody2D = GetComponent<Rigidbody2D>();
        rigidBody2D.freezeRotation = true;
        
        spriteRenderer.sprite = enemyData.enemySprite;
        spriteRenderer.color = enemyData.enemyColor;
        horizontalSpeed = enemyData.horizontalSpeed;
        verticalSpeed = enemyData.verticalSpeed;
        
    }

    public void Update()
    {
        rigidBody2D.velocity = new Vector2(horizontalSpeed, rigidBody2D.velocity.y);
        if (Input.GetMouseButton(0))
        {
            rigidBody2D.velocity = new Vector2(rigidBody2D.velocity.x, verticalSpeed);
        }
        else
        {
            rigidBody2D.velocity = new Vector2(rigidBody2D.velocity.x, -verticalSpeed);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "DestroyPoint")
        {
            Destroy(gameObject);
        }
    }


}
