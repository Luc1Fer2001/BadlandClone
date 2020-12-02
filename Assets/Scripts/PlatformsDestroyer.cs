using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformsDestroyer : MonoBehaviour
{
    public GameObject destroyPoint;

    public void Start()
    {
       destroyPoint = GameObject.Find("DestroyPoint");
       
    }
    void Update()
    {
        if(transform.position.x < destroyPoint.transform.position.x)
        {
            gameObject.SetActive(false);
        }
    }
}
