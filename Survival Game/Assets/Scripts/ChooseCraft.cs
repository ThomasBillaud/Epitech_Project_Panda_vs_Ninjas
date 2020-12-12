using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseCraft : MonoBehaviour
{
    public Image image;
    public bool selected = false;
    public int nbItemsRequired;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.mouseScrollDelta.y != 0 && selected == false)
        {
            image.rectTransform.sizeDelta = new Vector2(125, 125);
            selected = true;
        }
        else if (Input.mouseScrollDelta.y != 0 && selected == true)
        {
            image.rectTransform.sizeDelta = new Vector2(100, 100);
            selected = false;
        }
    }
}
