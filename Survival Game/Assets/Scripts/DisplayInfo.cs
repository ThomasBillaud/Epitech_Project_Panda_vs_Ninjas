using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayInfo : MonoBehaviour
{
    public Text Info;
    private BambooGrow Bamboo;
    private WaterBehaviour Water;
    private WallLife Wall;

    // Start is called before the first frame update
    void Start()
    {
        Info.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        Info.enabled = true;
        if (other.gameObject.tag == "Food")
        {
            Bamboo = other.gameObject.GetComponent<BambooGrow>();
            Info.text = "Bamboo : " + Bamboo.stockBamboo.ToString() + "/10";
        }
        else if (other.gameObject.tag == "Water")
        {
            Water = other.gameObject.GetComponent<WaterBehaviour>();
            Info.text = "Water : " + Water.stockWater.ToString() + "/" + Water.maxSize.ToString();
        }
        else if (other.gameObject.tag == "Wall")
        {
            Wall = other.gameObject.GetComponent<WallLife>();
            Info.text = "Wall life : " + Wall.health.ToString() + "/10";
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Info.enabled = false;
    }
}
