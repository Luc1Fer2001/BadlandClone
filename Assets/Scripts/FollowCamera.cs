using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    List<GameObject> enemyList;
    GameObject targetEnemy;
    public GameObject enemyCamera;
    public bool isFind = false;

    void Start()
    {
        enemyCamera = GameObject.Find("Main Camera");
        enemyList = new List<GameObject>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            GameObject enemy;
            enemy = collision.gameObject;
            enemyList.Add(enemy);
            isFind = true;
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            GameObject enemy;
            enemy = collision.gameObject;
            enemyList.Remove(enemy);
            isFind = true;
        }
    }
    GameObject FindTargetEnemy()
    {
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in enemyList)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                targetEnemy = go;
                distance = curDistance;
            }
        }
        return targetEnemy;
    }
    void Update()
    {
        if (isFind == true)
        {
            FindTargetEnemy();
        }
        if(enemyList.Count >= 1)
        {
            enemyCamera.transform.position = new Vector3(targetEnemy.transform.position.x, 0, -10);
        }
        else
        {
            FindTargetEnemy();
        }
            
    }
}
