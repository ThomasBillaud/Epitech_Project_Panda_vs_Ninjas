﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaMove : MonoBehaviour
{
    public Animator animator;
    public Vector2 direction;
    public float speed;
    private BambooGrow Bamboo;
    private WallLife Wall;
    Camera cam;
    Transform myTransform;
    DayNightCycle Cycle;
    bool hasRunAway = false;

    // Start is called before the first frame update
    void Start()
    {
        Cycle = GameObject.FindGameObjectWithTag("Cycle").GetComponent<DayNightCycle>();
        cam = Camera.main;
        myTransform = GetComponent<Transform>();
        if (transform.position.x < 0) {
            animator.SetBool("left", false);
            direction += Vector2.right;
        } else {
            direction += Vector2.left;
        }
        Debug.Log("Spawn Ninja at " + myTransform.position.x);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Food")
        {
            Bamboo = other.gameObject.GetComponent<BambooGrow>();
            if (Bamboo.stockBamboo > 0 && animator.GetBool("runAway") == false)
            {
                direction = Vector2.zero;
                animator.SetBool("attack", true);
                StartCoroutine(CutBamboo());
            }
        }
        if (other.gameObject.tag == "Wall" && animator.GetBool("runAway") == false)
        {
            Wall = other.gameObject.GetComponent<WallLife>();
            if (Wall.health > 0 && Cycle.IsDay == false) {
                direction = Vector2.zero;
                animator.SetBool("attack", true);
                StartCoroutine(DestroyWall());
            }
        }
    }

    IEnumerator CutBamboo()
    {
        yield return new WaitForSeconds(5);
        Bamboo.stockBamboo -= 1;
        animator.SetBool("runAway", true);
        FindObjectOfType<AudioManager>().Play("NinjaLaugh");
        if (animator.GetBool("left") == false) {
            direction += Vector2.left;
        } else {
            direction += Vector2.right;
        }
    }

    IEnumerator DestroyWall()
    {
        while (Wall.health > 0) {
            yield return new WaitForSeconds(5);
            Wall.health -= 1;
        }
        animator.SetBool("attack", false);
        if (animator.GetBool("left") == false) {
            direction += Vector2.right;
        } else {
            direction += Vector2.left;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Direction();
        if (Cycle.IsDay == true && hasRunAway == false)
        {
            hasRunAway = true;
            animator.SetBool("attack", false);
            StopAllCoroutines();
            if (animator.GetBool("left") == false) {
                animator.SetBool("left", true);
                direction += Vector2.left;
            } else {
                animator.SetBool("left", false);
                direction += Vector2.right;
            }
        }
    }

    void Direction()
    {
        transform.Translate(new Vector3(direction.x, direction.y, 0) * Time.deltaTime * speed);
    }

    private void OnBecameInvisible() {

        if (animator.GetBool("runAway") == true || Cycle.IsDay == true) 
        {
            Destroy(this.gameObject);
        }
    }
}
