using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed of movement
    public Vector3 currentPosition; // Current position of the player
    private GridManager gridManager; // Reference to the GridManager script
    public Vector3 CurrentPosition => transform.position;
    public PlayerMovement player;

    private void Start()
    {
        if (this == null)
        {
            Debug.LogError("Player object is null!");
            gameObject.SetActive(false);
        }
        currentPosition = transform.position; // Initialize current position
        gridManager = FindObjectOfType<GridManager>(); // Get reference to GridManager
    }

    private void Update()
    {
        HandleMovement();
    }
    public void Move(Vector3 newPosition)
    {
        
        if (this != null)
        {
            transform.position = newPosition;
        }
    }

    private void HandleMovement()
    {
        float horizontal = Input.GetAxis("Horizontal"); // A/D or Left/Right Arrow
        float vertical = Input.GetAxis("Vertical"); // W/S or Up/Down Arrow

        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;

        Vector3 newPosition = currentPosition + direction * moveSpeed * Time.deltaTime;

        // Debugging
        Debug.Log($"GridManager: {gridManager != null}");
        Debug.Log($"New Position: {newPosition}");

        if (gridManager == null)
        {
            Debug.LogError("GridManager is not assigned!");
            return; // Exit the method early
        }
        if (gridManager.IsTileWalkable(newPosition))
        {
            currentPosition = newPosition; // Update current position
            transform.position = currentPosition; // Move the player
            Debug.Log($"Player moved to: {transform.position}");
        }
        else
        {
            Debug.Log("Tile is not walkable.");
        }
    }

 
}