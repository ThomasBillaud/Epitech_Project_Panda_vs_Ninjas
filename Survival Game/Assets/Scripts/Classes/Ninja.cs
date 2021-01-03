using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Ninja
{
    public float[] position;
    public float speed;

    public Ninja (NinjaMove ninja)
    {
        position = new float[3];
        position[0] = ninja.transform.position.x;
        position[1] = ninja.transform.position.y;
        position[2] = ninja.transform.position.z;

        speed = ninja.speed;
    }
}
