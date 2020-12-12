using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Craft : MonoBehaviour
{
    private Inventory invBam;
    private Inventory invWat;
    public GameObject Bamboo;
    public GameObject Wall;
    public GameObject Crafting;
    GameObject craftUsed;
    public int nbItemsRequired;
    Camera cam;
    public bool craftEnabled = true;

    // Start is called before the first frame update
    void Start()
    {
        invBam = GameObject.FindGameObjectWithTag("InventoryBamboo").GetComponent<Inventory>();
        invWat = GameObject.FindGameObjectWithTag("InventoryWater").GetComponent<Inventory>();
        cam = Camera.main;
        craftUsed = Bamboo;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition;

        if (Input.GetKeyDown(KeyCode.E))
        {
            chooseCraft();
            displayInv();
        }
        if (invBam.selected && Input.GetMouseButtonDown(0) && invBam.stock >= nbItemsRequired && craftEnabled)
        {
            mousePosition = Camera.main.ScreenToWorldPoint(new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 0));
            Instantiate(craftUsed, new Vector3(mousePosition.x, -1.85f, 0), Quaternion.identity);
            invBam.stock -= nbItemsRequired;
            if (craftUsed == Bamboo)
                FindObjectOfType<AudioManager>().Play("Harvest");
            else
                FindObjectOfType<AudioManager>().Play("Wall");
        }
    }

    void displayInv()
    {
        if (invBam.pause == true)
        {
            Time.timeScale = 1f;
            invBam.pause = false;
            invWat.pause = false;
            Crafting.SetActive(false);
        } else
        {
            Time.timeScale = 0f;
            invBam.pause = true;
            invWat.pause = true;
            Crafting.SetActive(true);
        }
    }

    void chooseCraft()
    {
        ChooseCraft actualCraft = Crafting.transform.Find("Craft Bamboo").transform.Find("Image").GetComponent<ChooseCraft>();
        
        if (actualCraft.selected == true)
        {
            craftUsed = Bamboo;
            nbItemsRequired = actualCraft.nbItemsRequired;
        } else
        {
            actualCraft = Crafting.transform.Find("Craft Wall").transform.Find("Image").GetComponent<ChooseCraft>();
            craftUsed = Wall;
            nbItemsRequired = actualCraft.nbItemsRequired;
        }
    }
}
