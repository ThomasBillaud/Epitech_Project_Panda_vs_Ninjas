using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Bamboo
{
    public float[] position;
    public int stockBamboo;
    public float growingTime;
    public int phase;
    public int divideStock;
    public int tmpStock;
    public int speed;

    public Bamboo (BambooGrow bambooGrow)
    {
        position = new float[3];
        position[0] = bambooGrow.transform.position.x;
        position[1] = bambooGrow.transform.position.y;
        position[2] = bambooGrow.transform.position.z;

        stockBamboo = bambooGrow.stockBamboo;
        growingTime = bambooGrow.growingTime;
        phase = bambooGrow.phase;
        divideStock = bambooGrow.divideStock;
        tmpStock = bambooGrow.tmpStock;
        speed = bambooGrow.speed;
    }
}
