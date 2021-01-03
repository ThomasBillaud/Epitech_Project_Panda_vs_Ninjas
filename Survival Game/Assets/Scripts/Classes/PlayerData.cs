using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public float[] position;
    public float hunger;
    public float thirst;
    public int invBamboo;
    public int invWater;
    public int days;

    public PlayerData (MovePlayer player, Hunger hungerValue, Thirst thirstValue, Inventory Bamboo, Inventory Water, CountDays Days)
    {
        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;

        hunger = hungerValue.stockFillAmount;

        thirst = thirstValue.stockFillAmount;

        invBamboo = Bamboo.stock;

        invWater = Water.stock;

        days = Days.Days;
    }
}
