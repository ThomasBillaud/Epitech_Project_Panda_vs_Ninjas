using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountDays : MonoBehaviour
{
    public int Days = 1;
    public TMP_Text Counter;
    public DayNightCycle Cycle;
    bool ThisDay = true;
    static int nbDays = 1;

    // Start is called before the first frame update
    void Start()
    {
        if (Cycle != null)
            Cycle.GetComponent<DayNightCycle>();
        else
            DisplayResult();
    }

    // Update is called once per frame
    void Update()
    {
        if (Cycle != null && Cycle.IsDay == true && ThisDay == false)
        {
            ThisDay = true;
            Days++;
            nbDays++;
            Counter.text = "Day : " + Days;
        }
        if (Cycle != null && Cycle.IsDay == false)
        {
            ThisDay = false;
        }
    }

    void DisplayResult()
    {
        Counter.text = "You survived : " + nbDays + " days";
    }
}
