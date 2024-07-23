using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    private PlayerMovement player;
    public void Initialize(PlayerMovement playerReference)
    {
        player = playerReference;
    }

    void Start()
    {
        player = FindObjectOfType<PlayerMovement>(); // Find the player object in the scene
    }
    

    void OnTriggerEnter(Collider other)
    {
       
        if (other.CompareTag("Player"))
        {
            DisablePlayer(other.gameObject);
        }
    }
    private void DisablePlayer(GameObject player)
    {
        if (player != null) // Check if player is not null
        {
            player.SetActive(false); // Disable the player GameObject
        }
    }
}
