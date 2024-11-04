using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public GameObject hexagonPrefab; // Your hexagon prefab
    public int gridWidth = 10; // Number of hexagons horizontally
    public int gridHeight = 10; // Number of hexagons vertically
    public float hexagonSize = 1.0f; // Size of the hexagon

    private float hexWidth;
    private float hexHeight;

    // Start is called before the first frame update
    void Start()
    {
        hexWidth = hexagonSize * 2; // Width of the hexagon
        hexHeight = Mathf.Sqrt(3) * hexagonSize; // Height of the hexagon

        for (int q = 0; q < gridWidth; q++)
        {
            for (int r = 0; r < gridHeight; r++)
            {
                float xOffset = q * hexWidth * 0.75f; // Horizontal offset
                float yOffset = r * hexHeight; // Vertical offset

                // Adjust for odd/even rows to create the hex pattern
                if (q % 2 == 1) yOffset += hexHeight / 2;

                Vector2 position = new Vector2(xOffset, yOffset);
                GameObject hex = Instantiate(hexagonPrefab, position, Quaternion.identity);
                hex.name = $"Hex_{q}_{r}"; // Naming for reference
            }
        }

    }

   
    // Update is called once per frame
    void Update()
    {
        
    }
}
