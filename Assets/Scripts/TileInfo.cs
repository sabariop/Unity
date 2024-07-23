using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileInfo : MonoBehaviour
{
    public int x;
    public int y;

    private Vector3 originalPosition;
    private Vector3 popUpPosition;
    public Vector2Int gridPosition; 
    public bool isWalkable = true; 

    void Start()
    {
        originalPosition = transform.position;
        popUpPosition = originalPosition + new Vector3(0, 0.25f, 0); // Adjust the y-value to determine the pop-up height
     
    }

    // Method to pop up the tile
    public void PopUp()
    {
        transform.position = popUpPosition;
    }

    // Method to reset the tile to its original position
    public void ResetPosition()
    {
        transform.position = originalPosition;
    }
}