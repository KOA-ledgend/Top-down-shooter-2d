using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinding : MonoBehaviour
{
    GridMaker grid;

    void pathfinding(Vector2 startingPosition, Vector2 targetPosition)
    {
        startingPosition = grid.transform.position;
        targetPosition = grid.transform.position;
    }

    private void Awake()
    {
        grid = GetComponent<GridMaker>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
