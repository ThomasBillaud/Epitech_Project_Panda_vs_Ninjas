using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradePond : MonoBehaviour
{
    private Inventory Inv;
    private WaterBehaviour Water;
    bool inTrigger = false;
    private Craft Enabled;

    // Start is called before the first frame update
    void Start()
    {
        Inv = GameObject.FindGameObjectWithTag("InventoryBamboo").GetComponent<Inventory>();
        Enabled = GameObject.FindObjectOfType<Craft>().GetComponent<Craft>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Water")
        {
            Water = other.gameObject.GetComponent<WaterBehaviour>();
            inTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        inTrigger = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (inTrigger && Inv.selected && Inv.stock >= 10 && Input.GetMouseButtonDown(0))
        {
            Enabled.craftEnabled = false;
            Water.maxSize += 10;
            Inv.stock -= 10;
            Enabled.craftEnabled = true;
        }
    }
}
