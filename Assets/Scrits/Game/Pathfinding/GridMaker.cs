using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GridMaker : MonoBehaviour
{
    public LayerMask unwalkable;
    public Vector2 grideWorldSize;
    public float nodeRadius;
    Nodes[,] grid;
    float nodeDiameter;
    int gridSizeX, gridSizeY;

    // Start is called before the first frame update
    void Start()
    {
        nodeDiameter = nodeRadius * 2;
        gridSizeX = Mathf.RoundToInt(grideWorldSize.x / nodeDiameter);
        gridSizeY = Mathf.RoundToInt(grideWorldSize.y / nodeDiameter);
        CreateGrid();

        Debug.Log($"Grid Size: {gridSizeX} by {gridSizeY}"); // Debugging grid dimensions
        CreateGrid();

    }

    void CreateGrid()
    {
        grid = new Nodes[gridSizeX, gridSizeY];
        Vector2 worldBottomLeft = (Vector2)transform.position - Vector2.right * grideWorldSize.x / 2 - Vector2.up * grideWorldSize.y / 2;
        for (int x = 0; x < gridSizeX; x++)
        {
            for (int y = 0; y < gridSizeY; y++)
            {
                Vector3 worldPoint = new Vector3(
                worldBottomLeft.x + (x * nodeDiameter + nodeRadius),
                worldBottomLeft.y + (y * nodeDiameter + nodeRadius),
                 -1 // Z-coordinate to push tiles behind everything
);
                bool passable = !(Physics.CheckSphere(worldPoint, nodeRadius, unwalkable));

                // Debugging each node's position and passable state
                Debug.Log($"Node at ({x}, {y}) - Position: {worldPoint} - Passable: {passable}");

                grid[x, y] = new Nodes(passable, worldPoint);
            }
        }
    }


    // Update is called once per frame
    void Update()
    {

    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, grideWorldSize);
        if (grid != null)
        {
            foreach (Nodes n in grid)
            {
                Gizmos.color = (n.passable) ? Color.white : Color.red;
                Gizmos.DrawWireCube(new Vector3(n.worldPosition.x, n.worldPosition.y, -1), Vector3.one * (nodeDiameter - 0.1f));
            }
        }
    }
}
