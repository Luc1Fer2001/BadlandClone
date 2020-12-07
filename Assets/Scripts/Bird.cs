using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public SpriteRenderer[] spriteRenderer;
    [SerializeField]
    private float verticalSpeed = 2;
    private Rigidbody2D rigidBody2D;
    public void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    public void Update()
    {
        if (Input.GetMouseButton(0))
        {
            rigidBody2D.velocity = new Vector2(rigidBody2D.velocity.x, verticalSpeed);
        }
        else
        {
            rigidBody2D.velocity = new Vector2(rigidBody2D.velocity.x, -verticalSpeed);
        }

        if(transform.position.x <= -12 || transform.position.y < -6 || transform.position.y > 6)
        {
            Destroy(gameObject);
            
        }
    }


}
