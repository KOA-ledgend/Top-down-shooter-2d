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
    float nodeWidth, nodeHeight;
    float nodeDiameter;
    int gridSizeX, gridSizeY;

    // Start is called before the first frame update
    void Start()
    {
        nodeWidth = Mathf.Sqrt(3) * nodeRadius;   // Width of a hexagon
        nodeHeight = 2 * nodeRadius;              // Height of a hexagon

        // nodeDiameter = nodeRadius * 2;
        // gridSizeX =Mathf.RoundToInt(grideWorldSize.x / nodeDiameter);
        // gridSizeY = Mathf.RoundToInt(grideWorldSize.y / nodeDiameter);

        gridSizeX = Mathf.RoundToInt(grideWorldSize.x / nodeWidth);
        gridSizeY = Mathf.RoundToInt(grideWorldSize.y / (nodeHeight * 0.75f)); // Reduced to account for row offset
        CreateGrid();

        Debug.Log($"Grid Size: {gridSizeX} by {gridSizeY}"); // Debugging grid dimensions
        CreateGrid();

    }

    void CreateGrid()
    {
        /* grid = new Nodes[gridSizeX, gridSizeY];
         Vector2 worldBottomLeft = (Vector2)transform.position - Vector2.right * grideWorldSize.x / 2 - Vector2.up * grideWorldSize.y / 2;
         for (int x = 0; x < gridSizeX; x++)
         {
             for (int y = 0; y < gridSizeY; y++)
             {
                 Vector2 worldPoint = worldBottomLeft + Vector2.right * (x * nodeDiameter + nodeRadius) + Vector2.up * (y * nodeDiameter + nodeRadius);
                 bool passable = !(Physics2D.OverlapCircle(worldPoint, nodeRadius, unpassabeMask));

                 // Debugging each node's position and passable state
                 Debug.Log($"Node at ({x}, {y}) - Position: {worldPoint} - Passable: {passable}");

                 grid[x,y] = new Nodes(passable, worldPoint);
             }
         }*/

        grid = new Nodes[gridSizeX, gridSizeY];
        Vector2 worldBottomLeft = (Vector2)transform.position - Vector2.right * grideWorldSize.x / 2 - Vector2.up * grideWorldSize.y / 2;

        for (int x = 0; x < gridSizeX; x++)
        {
            for (int y = 0; y < gridSizeY; y++)
            {
                // Calculate offset for staggered rows
                float xOffset = (y % 2 == 0) ? 0 : nodeWidth / 2;
                Vector2 worldPoint = worldBottomLeft + Vector2.right * (x * nodeWidth + xOffset) + Vector2.up * (y * nodeHeight * 0.75f);


                bool passable = !(Physics2D.OverlapCircle(worldPoint, nodeRadius, unpassabeMask));
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
        /*Gizmos.DrawWireCube(transform.position, grideWorldSize);
        if (grid != null)
        {
            foreach (Nodes n in grid)
            {
                Gizmos.color = (n.passable) ? Color.white : Color.red;
                Gizmos.DrawCube(n.worldPosition, Vector2.one * (nodeDiameter - 0.1f));
            }
        }*/

        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(transform.position, grideWorldSize);

        if (grid != null)
        {
            foreach (Nodes n in grid)
            {
                Gizmos.color = n.passable ? Color.white : Color.red;
                DrawHexagonGizmo(n.worldPosition);
            }
        }
    }

    void DrawHexagonGizmo(Vector2 position)
    {
        Vector3[] hexCorners = new Vector3[6];
        for (int i = 0; i < 6; i++)
        {
            float angle = Mathf.Deg2Rad * (60 * i);
            hexCorners[i] = new Vector3(position.x + nodeRadius * Mathf.Cos(angle), position.y + nodeRadius * Mathf.Sin(angle), 0);
        }

        // Draw hexagon edges
        for (int i = 0; i < 6; i++)
        {
            Gizmos.DrawLine(hexCorners[i], hexCorners[(i + 1) % 6]);
        }
    }
}
