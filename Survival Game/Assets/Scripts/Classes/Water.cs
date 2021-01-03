using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Water
{
    public float[] position;
    public int stockWater;
    public int maxSize;
    public bool ThisDay;

    public Water (WaterBehaviour water)
    {
        position = new float[3];
        position[0] = water.transform.position.x;
        position[1] = water.transform.position.y;
        position[2] = water.transform.position.z;

        stockWater = water.stockWater;
        maxSize = water.maxSize;
        ThisDay = water.ThisDay;
    }
}
