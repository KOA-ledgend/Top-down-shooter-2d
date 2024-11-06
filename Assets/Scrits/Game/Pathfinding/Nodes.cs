using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nodes 
{
    public bool passable;
    public Vector2 worldPosition;

    public Nodes(bool _passable, Vector2 _worldPosition)
    {
        this.passable = _passable;
        this.worldPosition = _worldPosition;
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

   
}
