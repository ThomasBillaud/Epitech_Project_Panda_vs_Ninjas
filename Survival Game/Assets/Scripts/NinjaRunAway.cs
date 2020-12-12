using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaRunAway : MonoBehaviour
{
    public NinjaMove Move;
    public Animator animator;
    private Vector2 direction;
    DayNightCycle Cycle;

    // Start is called before the first frame update
    void Start()
    {
        Cycle = FindObjectOfType<DayNightCycle>().GetComponent<DayNightCycle>();
        direction = Move.direction;
    }

    // Update is called once per frame
    void Update()
    {
        if (Cycle.alphaLevel > 0.5f)
        {
            Move.enabled = false;
            if (animator.GetBool("left") == false) {
                direction += Vector2.left;
            } else {
                direction += Vector2.right;
        }
        }
    }
}
