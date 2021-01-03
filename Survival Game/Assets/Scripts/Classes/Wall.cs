using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Wall
{
    public float[] position;
    public int wallLife;

    public Wall (WallLife wall)
    {
        position = new float[3];
        position[0] = wall.transform.position.x;
        position[1] = wall.transform.position.y;
        position[2] = wall.transform.position.z;
        wallLife = wall.health;
    }
}
