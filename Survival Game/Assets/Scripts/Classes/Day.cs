using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Day
{
    public float DayTime;
    public float NightTime;
    public float StartCycle;
    public float alphaLevel;
    public bool IsDawn;
    public bool IsDay;

    public Day (DayNightCycle Cycle)
    {
        DayTime = Cycle.DayTime;
        NightTime = Cycle.NightTime;
        StartCycle = Cycle.StartCycle;
        alphaLevel = Cycle.alphaLevel;
        IsDawn = Cycle.IsDawn;
        IsDay = Cycle.IsDay;
    }

}
