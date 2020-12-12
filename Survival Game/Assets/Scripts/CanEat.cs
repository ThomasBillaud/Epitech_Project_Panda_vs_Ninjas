using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanEat : MonoBehaviour
{
    private Hunger Barre;
    private Inventory Inv;
    private Inventory Water;
    bool inTrigger = false;
    private BambooGrow Bamboo;

    // Start is called before the first frame update
    void Start()
    {
        Barre = GameObject.FindGameObjectWithTag("HealthBar").GetComponent<Hunger>();
        Inv = GameObject.FindGameObjectWithTag("InventoryBamboo").GetComponent<Inventory>();
        Water = GameObject.FindGameObjectWithTag("InventoryWater").GetComponent<Inventory>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Food")
        {
            Bamboo = other.gameObject.GetComponent<BambooGrow>();
            inTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.tag == "Food")
        {
            inTrigger = false;
        }    
    }

    void Update()
    {
        if (inTrigger && Input.GetKeyDown(KeyCode.S))
        {
            if (Bamboo.stockBamboo > 0) {
                FindObjectOfType<AudioManager>().Play("Harvest");
                Inv.stock += 1;
                Bamboo.stockBamboo -= 1;
            }
        }
        if (Inv.stock > 0 && Input.GetMouseButtonDown(1) && Inv.selected == true)
        {
            Barre.Appetite = -0.1f;
            Inv.stock -= 1;
            FindObjectOfType<AudioManager>().Play("Harvest");
        }
        if (Water.selected && Input.GetMouseButtonDown(0) && inTrigger && Water.stock > 0 && Bamboo.speed < 4)
        {
            Bamboo.speed++;
            Water.stock--;
            FindObjectOfType<AudioManager>().Play("Drink");
        }
    }
}
