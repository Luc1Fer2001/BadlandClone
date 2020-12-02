using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformsGenerator : MonoBehaviour
{
    public GameObject platformPrefab;
    public Transform generatorPoint;

    public int platformAmount;
    float platformWidth;

    List<GameObject> platforms;

    
    void Start()
    {
        platformWidth = platformPrefab.GetComponent<BoxCollider2D>().size.x;
        platforms = new List<GameObject>();

        for (int i = 0; i < platformAmount; i++)
        {
            GameObject objec = (GameObject) Instantiate(platformPrefab);
            objec.SetActive(false);
            platforms.Add(objec);
        }
    }

    void Update()
    {
        if(transform.position.x < generatorPoint.position.x)
        {
            transform.position = new Vector3(transform.position.x + platformWidth, transform.position.y, transform.position.z);
            GameObject newPlatform = GetPlatform();
            newPlatform.transform.position = transform.position;
            newPlatform.transform.rotation = transform.rotation;
            newPlatform.SetActive(true);
        }
    }
    public GameObject GetPlatform()
    {
        for (int i = 0; i < platforms.Count; i++)
        {
            if (!platforms[i].activeInHierarchy)
            {
                return platforms[i];
            }
        }
        GameObject objec = (GameObject)Instantiate(platformPrefab);
        objec.SetActive(false);
        platforms.Add(objec);
        return objec;
    }
}
