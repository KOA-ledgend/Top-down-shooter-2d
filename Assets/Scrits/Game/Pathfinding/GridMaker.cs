using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GridMaker : MonoBehaviour
{
    public LayerMask unpassabeMask;
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
                Vector2 worldPoint = worldBottomLeft + Vector2.right * (x * nodeDiameter + nodeRadius) + Vector2.up * (y * nodeDiameter + nodeRadius);
                bool passable = !(Physics2D.OverlapCircle(worldPoint, nodeRadius, unpassabeMask));

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
                Gizmos.color = (n.passable) ? Color.green : Color.red;
                Gizmos.DrawWireCube(n.worldPosition, Vector2.one * (nodeDiameter - 0.1f));
            }
        }
    }
}
