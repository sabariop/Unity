using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public ObstacleData obstacleData; // Reference to the Scriptable Object
    public GameObject obstaclePrefab;
    public Vector2Int[] obstaclePositions;
    public GridManager gridManager;
    private void Start()
    {
        // Ensure gridManager is assigned
        if (gridManager == null)
        {
            gridManager = FindObjectOfType<GridManager>();
        }

        if (gridManager == null)
        {
            Debug.LogError("GridManager is not found in the scene!");
        }
        GameObject obstacle = Instantiate(obstaclePrefab, Vector3.zero, Quaternion.identity);
        GenerateObstacles();
    }

    public void GenerateObstacles()
    {
        Debug.Log("Generating obstacles...");
        // Clear existing obstacles if necessary
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Obstacle"))
        {
            Destroy(obj);
        }
        foreach (Vector2Int pos in obstaclePositions)
        {
            Vector3 obstaclePosition = new Vector3(pos.x, 0.5f, pos.y);
            GameObject obstacle = Instantiate(obstaclePrefab, obstaclePosition, Quaternion.identity);

            // Ensure the obstacle has a collider
            SphereCollider collider = obstacle.AddComponent<SphereCollider>();
            collider.radius = 0.5f; 
        }
        CreateObstacleAt(2, 2);
        CreateObstacleAt(2, 5);
        CreateObstacleAt(1, 2);

     
        CreateObstacleAt(5, 5);
        CreateObstacleAt(7, 5);
        CreateObstacleAt(5, 3);


        // Iterate through the obstacle grid and instantiate obstacles
        for (int x = 0; x < 10; x++)
        {
            for (int y = 0; y < 10; y++)
            {
                if (obstacleData.obstacleGrid[x, y] && (x != 2 || y != 2) && (x != 5 || y != 5))
                {
                    CreateObstacleAt(x, y);
                }
            }
        }
    }
    public bool IsTileWalkable(Vector2Int gridPosition)
    {
        bool isWalkable = !System.Array.Exists(obstaclePositions, pos => pos == gridPosition);
        Debug.Log($"Tile at {gridPosition} is walkable: {isWalkable}");
        return isWalkable;
    }
    private void CreateObstacleAt(int x, int y)
    {
        Debug.Log($"Creating obstacle at ({x}, {y})");
        Vector3 position = new Vector3(x, 0.5f, y);
        GameObject obstacle = Instantiate(obstaclePrefab, position, Quaternion.identity);
        obstacle.transform.localScale = Vector3.one * 0.5f; // Adjust the scale of the obstacle
        obstacle.tag = "Obstacle"; // Tag the obstacle for easy identification
    }
}