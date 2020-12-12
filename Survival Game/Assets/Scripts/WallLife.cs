using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallLife : MonoBehaviour
{
    public int health;
    public BoxCollider2D hitbox;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0) {
            health = 0;
            animator.SetBool("Alive", false);
        }
        if (health > 0) {
            animator.SetBool("Alive", true);
        }
    }
}
