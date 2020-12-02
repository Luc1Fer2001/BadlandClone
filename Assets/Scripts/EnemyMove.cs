using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField]
    private float horizontalSpeed;
    [SerializeField]
    private float verticalSpeed;
    public Camera enemyCamera;

    public Rigidbody2D rigidBody2D;

    public void Start()
    {
    }

    public void Update()
    {
        rigidBody2D.velocity = new Vector2(horizontalSpeed, rigidBody2D.velocity.y);
        enemyCamera.transform.position = new Vector3(transform.position.x, 0, -10);
        if(Input.GetMouseButton(0))
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
        if(collision.tag == "DestroyPoint")
        {
            Destroy(gameObject);
        }
    }
}
