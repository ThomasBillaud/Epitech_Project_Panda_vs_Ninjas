using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBehaviour : MonoBehaviour
{
    public int stockWater;
    DayNightCycle Cycle;
    public int maxSize;
    bool ThisDay = false;
    public Animator animator;
    private Craft Enabled;

    // Start is called before the first frame update
    void Start()
    {
        Cycle = GameObject.FindGameObjectWithTag("Cycle").GetComponent<DayNightCycle>();
        animator.GetComponent<Animator>();
        Enabled = GameObject.FindObjectOfType<Craft>().GetComponent<Craft>();
    }

    // Update is called once per frame
    void Update()
    {
        if (stockWater < maxSize && Cycle.IsDay == true && ThisDay == false)
        {
            ThisDay = true;
            animator.SetBool("Stock", true);
            stockWater = maxSize;
        }
        if (Cycle.IsDay == false)
        {
            ThisDay = false;
        }
        if (stockWater <= 0)
        {
            animator.SetBool("Stock", false);
            FindObjectOfType<AudioManager>().StopPlaying("Water");
        }
    }

    private void OnBecameVisible() {
        if (stockWater > 0)
            FindObjectOfType<AudioManager>().Play("Water");
    }

    private void OnBecameInvisible() {
        FindObjectOfType<AudioManager>().StopPlaying("Water");
    }

    private void OnMouseOver() {
        Enabled.enabled = false;
    }

    private void OnMouseExit() {
        Enabled.enabled = true;
    }
}
