using System.Collections;
using System.Collections.Generic;
using UnityEngine;



    


public class EnemyAI : MonoBehaviour, IAI
{
    public float moveSpeed = 2.0f;
    private PlayerMovement player;
    private Vector3 targetPosition;
    private bool isMoving = false;

    void Start()
    {
        player = FindObjectOfType<PlayerMovement>(); // Find the player in the scene
        targetPosition = transform.position; // Start at the enemy's initial position
    }

    public void UpdateAI()
    {
        if (!isMoving)
        {
            MoveTowardsPlayer();
        }
        else
        {
            StayStill();
        }
    }

    private void MoveTowardsPlayer()
    {
        Vector3 playerPosition = player.CurrentPosition;
        Vector3[] adjacentTiles = GetAdjacentTiles(playerPosition);

        // Choose a random adjacent tile to move towards
        targetPosition = adjacentTiles[Random.Range(0, adjacentTiles.Length)];
        isMoving = true;
    }

    private Vector3[] GetAdjacentTiles(Vector3 playerPosition)
    {
        return new Vector3[]
        {
            new Vector3(playerPosition.x + 1, playerPosition.y, playerPosition.z), // Right
            new Vector3(playerPosition.x - 1, playerPosition.y, playerPosition.z), // Left
            new Vector3(playerPosition.x, playerPosition.y, playerPosition.z + 1), // Up
            new Vector3(playerPosition.x, playerPosition.y, playerPosition.z - 1)  // Down
        };
    }

    private void StayStill()
    {
        // Move towards the target position
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        // Check if the enemy has reached the target position
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            isMoving = false; // Stop moving until the player moves
        }
    }
}

