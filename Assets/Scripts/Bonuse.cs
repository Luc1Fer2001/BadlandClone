using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonuse : MonoBehaviour
{
    private bool isActive = true;
    [SerializeField]
    private GameObject birdPrefab;
    private Bird birdSettings;
    private SpriteRenderer sprite;
    void Start()
    {
        sprite = gameObject.GetComponent<SpriteRenderer>();
        sprite.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bird")
        {
            GameObject newBird = Instantiate(birdPrefab, new Vector3(transform.position.x + 1.5f, transform.position.y, 0), Quaternion.identity) as GameObject;
            birdSettings = newBird.GetComponent<Bird>();
            birdSettings.spriteRenderer[0].color = sprite.color;
            gameObject.SetActive(false);
        }
    }
}
