using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BambooGrow : MonoBehaviour
{
    public int stockBamboo;
    DayNightCycle Cycle;
    float growingTime;
    int phase = 0;
    int divideStock = 24;
    int tmpStock = 1;
    public Animator animator;
    public int speed = 1;

    // Start is called before the first frame update
    void Start()
    {
        Cycle = GameObject.FindGameObjectWithTag("Cycle").GetComponent<DayNightCycle>();
        animator.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (stockBamboo < 10 && Cycle.IsDay == true) {
            growingTime += (Time.deltaTime % 60) * speed;
            string test = growingTime.ToString("Time is 000");
            Debug.Log(test);
            AddPhase();
            if (growingTime / divideStock > 1) {
                stockBamboo++;
                tmpStock++;
                divideStock = 24*tmpStock;
            }
            if (growingTime >= 120) {
                growingTime = 0;
                tmpStock = 1;
                divideStock = 24;
            }
        }
        if (Cycle.IsDay == false)
        {
            speed = 1;
        }
    }

    void AddPhase()
    {
        int[] nbphases = new int[] {3, 5, 7};
        int i = 0;

        while (i < 3 && stockBamboo > nbphases[i]) {
            i++;
        }
        phase = i;
        animator.SetInteger("Phase", phase);
    }

}
