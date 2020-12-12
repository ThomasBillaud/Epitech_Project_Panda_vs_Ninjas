using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairWall : MonoBehaviour
{
    private WallLife Wall;
    private Inventory Inv;
    bool inTrigger = false;

    // Start is called before the first frame update
    void Start()
    {
        Inv = GameObject.FindGameObjectWithTag("InventoryBamboo").GetComponent<Inventory>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Wall")
        {
            Wall = other.GetComponent<WallLife>();
            inTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.tag == "Wall")
        {
            inTrigger = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (inTrigger && Input.GetKeyDown(KeyCode.S))
        {
            if (Wall.health != 10 && Inv.stock > 0)
            {
                Inv.stock -= 1;
                Wall.health += 1;
            }
        }
    }
}
