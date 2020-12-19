using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanDrink : MonoBehaviour
{
    private Thirst Barre;
    private Inventory Inv;
    bool inTrigger = false;
    private WaterBehaviour Water;

    // Start is called before the first frame update
    void Start()
    {
        Barre = GameObject.FindGameObjectWithTag("WaterBar").GetComponent<Thirst>();
        Inv = GameObject.FindGameObjectWithTag("InventoryWater").GetComponent<Inventory>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Water")
        {
            Water = other.gameObject.GetComponent<WaterBehaviour>();
            if (Water.stockWater > 0)
            {
                inTrigger = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.tag == "Water")
        {
            inTrigger = false;
        }
    }
    void Update()
    {
        if (inTrigger && Input.GetKeyDown(KeyCode.S))
        {
            if (Water.stockWater > 0 && Inv.stock < 30) {
                Inv.stock += 1;
                Water.stockWater -= 1;
                FindObjectOfType<AudioManager>().Play("Drink");
            }
        }
        if (Inv.stock > 0 && Input.GetMouseButtonDown(1) && Inv.selected == true)
        {
            Barre.Thirsty = -0.1f;
            Inv.stock -=1;
            FindObjectOfType<AudioManager>().Play("Drink");
        }
    }
}
