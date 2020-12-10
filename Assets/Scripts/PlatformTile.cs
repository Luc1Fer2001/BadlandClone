using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformTile : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;
    public GameObject[] obstacles;
    public GameObject[] bonuses;

    public void ActivateRandomObstacle()
    {
        DeactivateAllObstacles();

        System.Random random = new System.Random();
        int randomNumber = random.Next(0, obstacles.Length);
        obstacles[randomNumber].SetActive(true);
    }

    public void DeactivateAllObstacles()
    {
        for (int i = 0; i < obstacles.Length; i++)
        {
            obstacles[i].SetActive(false);
        }
    }

    public void ActivateRandomBonuse()
    {
        DeactivateAllBonuse();

        System.Random random = new System.Random();
        int randomNumber = random.Next(0, bonuses.Length);
        bonuses[randomNumber].SetActive(true);
    }

    public void DeactivateAllBonuse()
    {
        for (int i = 0; i < bonuses.Length; i++)
        {
            bonuses[i].SetActive(false);
        }
    }
}
