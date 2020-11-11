using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormAgent : MonoBehaviour
{
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        //Check if the worm is moving
        Vector2 velocity = gameObject.GetComponent<Rigidbody2D>().velocity;

        if (velocity.magnitude == 0f)
        {
            animator.SetBool("moving", false);
        }
        else
        {
            animator.SetBool("moving", true);
        } 
    }
}
