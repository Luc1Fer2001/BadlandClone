using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundGenerator : MonoBehaviour
{
    [SerializeField]
    private Camera mainCamera;
    public Transform startPoint;
    public PlatformTile tilePrefab;
    [SerializeField]
    private float movingSpeed = 12;
    [SerializeField]
    private int tilesToPreSpawn = 3;
    [SerializeField]
    private int tilesWithoutObstacles = 6;

    List<PlatformTile> spawnedTiles = new List<PlatformTile>();
    float score = 0;

    public static GroundGenerator instance;

    void Start()
    {
        instance = this;

        Vector3 spawnPosition = startPoint.position;
        int tilesWithNoObstaclesTmp = tilesWithoutObstacles;
        for (int i = 0; i < tilesToPreSpawn; i++)
        {
            spawnPosition -= tilePrefab.startPoint.localPosition;
            PlatformTile spawnedTile = Instantiate(tilePrefab, spawnPosition, Quaternion.identity) as PlatformTile;
            if (tilesWithNoObstaclesTmp > 0)
            {
                spawnedTile.DeactivateAllObstacles();
                spawnedTile.DeactivateAllBonuse();
                tilesWithNoObstaclesTmp--;
            }
            else
            {
                spawnedTile.ActivateRandomObstacle();
                spawnedTile.ActivateRandomBonuse();
            }

            spawnPosition = spawnedTile.endPoint.position;
            spawnedTile.transform.SetParent(transform);
            spawnedTiles.Add(spawnedTile);
        }
    }

    void Update()
    {
            transform.Translate(-spawnedTiles[0].transform.right * Time.deltaTime * (movingSpeed + (score / 500)), Space.World);
            score += Time.deltaTime * movingSpeed;

        if (mainCamera.WorldToViewportPoint(spawnedTiles[0].endPoint.position).x < 0)
        {
            PlatformTile tileTmp = spawnedTiles[0];
            spawnedTiles.RemoveAt(0);
            tileTmp.transform.position = spawnedTiles[spawnedTiles.Count - 1].endPoint.position - tileTmp.startPoint.localPosition;
            tileTmp.ActivateRandomObstacle();
            tileTmp.ActivateRandomBonuse();
            spawnedTiles.Add(tileTmp);
        }
    }
}
