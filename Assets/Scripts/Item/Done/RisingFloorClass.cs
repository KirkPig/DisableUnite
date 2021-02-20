using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RisingFloorClass 
{
    public Vector3 position;
    public Vector2Int activeRange;

    public RisingFloorClass(Vector3 position, Vector2Int activeRange)
    {
        this.position = position;
        this.activeRange = activeRange;
    }
   
}
