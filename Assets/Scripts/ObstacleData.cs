using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="ObstacleData", menuName ="ScriptableObjects/ObstacleData")]
public class ObstacleData : ScriptableObject
{
    public bool[,] obstacleGrid;
    
    public void ToggleObstacle(int x, int y)
    {
        obstacleGrid[x, y] = !obstacleGrid[x, y];
    }
  
}