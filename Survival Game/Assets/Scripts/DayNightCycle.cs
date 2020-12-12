using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class DayNightCycle : MonoBehaviour
{
    public float DayTime;
    private float StartCycle = 0;
    public float alphaLevel = 0.00f;
    private bool IsDawn = true;
    public bool IsDay = true;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(InvokeMethod(Cycle, 0.25f));
    }

    public void Cycle ()
    {
        GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1, alphaLevel);
    }

    public IEnumerator InvokeMethod(Action method, float interval)
    {
        while (enabled)
        {
            if (alphaLevel >= 1)
            {
                IsDawn = false;
            }
            if (alphaLevel <= 0)
            {
                IsDawn = true;
            }
            if (alphaLevel >= 1 || alphaLevel <= 0)
            {
                yield return new WaitForSeconds(DayTime);
            }
            if (IsDawn == true) {
                StartCycle++;
                alphaLevel += 0.005f;
            } else if (IsDawn == false) {
                StartCycle--;
                alphaLevel -= 0.005f;
            }
            method();
            yield return new WaitForSeconds(interval);
        }
    }

    public void Update() {
        if (alphaLevel <= 0.5) {
            IsDay = true;
        } else {
            IsDay = false;
        }
    }

}
