using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public string Name;
    public Text Inv;
    public int stock;
    public bool selected = false;
    public Image image;
    public bool pause = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Inv.text = Name + " : " + stock;
        if (Input.mouseScrollDelta.y != 0 && selected == false && pause == false)
        {
            image.rectTransform.sizeDelta = new Vector2(125, 125);
            selected = true;
        }
        else if (Input.mouseScrollDelta.y != 0 && selected == true && pause == false)
        {
            image.rectTransform.sizeDelta = new Vector2(100, 100);
            selected = false;
        }
    }
}
