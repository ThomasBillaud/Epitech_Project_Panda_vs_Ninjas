using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Hunger : MonoBehaviour
{
    static Image Barre;
    public float Appetite;
    public float Valeur;
    public CountDays DaysCounter;
    int ActualDay;

    // Start is called before the first frame update
    void Start()
    {
        ActualDay = DaysCounter.Days;
        Barre = GetComponent<Image>();
        StartCoroutine(InvokeMethod(0.01f));
    }

    public IEnumerator InvokeMethod(float interval)
    {
        while (enabled)
        {
            if (DaysCounter.Days > ActualDay)
            {
                ActualDay = DaysCounter.Days;
                Valeur += 0.00005f;
            }
            Barre.fillAmount -= Appetite;
            Appetite = Valeur;
            if (Barre.fillAmount <= 0)
            {
                FindObjectOfType<GameEnd>().EndGame();
            }
            yield return new WaitForSeconds(interval);
        }
    }

}