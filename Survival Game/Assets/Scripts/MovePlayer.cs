using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public Animator animator;
    Transform myTransform;
    public float speed;
    private Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
        myTransform = GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        TakeInput();
        Direction();
    }

    void TakeInput()
    {
        direction = Vector2.zero;

        if (Input.GetKey(KeyCode.Q))
        {
            animator.SetBool("Idle", false);
            animator.SetBool("Left", true);
            direction += Vector2.left;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            animator.SetBool("Idle", false);
            animator.SetBool("Left", false);
            direction += Vector2.right;
        }
        else {
            animator.SetBool("Idle", true);
        }
    }

    void Direction()
    {
        myTransform.Translate(new Vector3(direction.x, direction.y, 0) * Time.deltaTime * speed);
    }


}
