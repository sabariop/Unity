using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TileRaycaster : MonoBehaviour
{
    public TMP_Text tileInfoText;
    private TileInfo lastTile; // To keep track of the last interacted tile

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            TileInfo tileInfo = hit.collider.GetComponent<TileInfo>();
            Debug.Log($"Hit: {hit.collider.name}"); // Log the name of the hit object

            if (tileInfo != null)
            {
                // Update the UI text with the tile's position.
                tileInfoText.text = "Tile Position: (" + tileInfo.x + ", " + tileInfo.y + ")";

                if (Input.GetMouseButtonDown(0)) // Left mouse button
                {
                    if (lastTile != null && lastTile != tileInfo)
                    {
                        lastTile.ResetPosition();
                    }

                    tileInfo.PopUp();
                    lastTile = tileInfo;
                }
            }
        }
        else
        {
            if (lastTile != null)
            {
                lastTile.ResetPosition();
                lastTile = null;
                tileInfoText.text = "Hover over a tile"; // Reset UI text
            }
        }
    }
}