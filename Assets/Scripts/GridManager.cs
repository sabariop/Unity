using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public GameObject tilePrefab; // Prefab for the tile (Unity Cube)
    public int gridSize = 10; // Size of the grid
    public TileInfo[,] tiles; // 2D array to hold tile references
    private bool[,] walkableTiles;

    private void Start()
    {
        GenerateGrid();
        InitializeGrid();
    }

    private void GenerateGrid()
    {
        tiles = new TileInfo[gridSize, gridSize];

        for (int x = 0; x < gridSize; x++)
        {
            for (int z = 0; z < gridSize; z++)
            {
                Vector3 position = new Vector3(x, 0, z);
                GameObject tileObject = Instantiate(tilePrefab, position, Quaternion.identity);
                TileInfo tile = tileObject.AddComponent<TileInfo>();
                tile.gridPosition = new Vector2Int(x, z);
                tiles[x, z] = tile;
            }
        }
    }

    public TileInfo GetTileAtPosition(Vector3 position)
    {
        int x = Mathf.RoundToInt(position.x);
        int z = Mathf.RoundToInt(position.z);

        if (x >= 0 && x < gridSize && z >= 0 && z < gridSize)
        {
            return tiles[x, z];
        }

        return null;
    }
    private void InitializeGrid()
    {
        walkableTiles = new bool[gridSize, gridSize];

        // For demonstration purposes, let's assume all tiles are walkable
        for (int x = 0; x < gridSize; x++)
        {
            for (int y = 0; y < gridSize; y++)
            {
                walkableTiles[x, y] = true; // Set to true for all tiles
            }
        }
    }
    public bool IsTileWalkable(Vector3 position)
    { 
            {
                int x = Mathf.RoundToInt(position.x);
                int y = Mathf.RoundToInt(position.z); // Assuming the grid is on the x-z plane

                if (x >= 0 && x < gridSize && y >= 0 && y < gridSize)
                {
                    return walkableTiles[x, y];
                }

                return false; // Out of bounds
            }
}   }  