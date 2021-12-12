using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    string direction;
    Rigidbody2D rb;
    Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        direction = "RIGHT";
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        if(x == 0f) {
            animator.SetBool("isRunning", false);
        } else {
            animator.SetBool("isRunning", true);
        }

        rb.velocity = new Vector2(x * speed, y * speed);

        //Debug.Log(direction);
        if((direction == "RIGHT" && x < 0) || (direction == "LEFT" && x > 0)) {
            direction = direction == "LEFT" ? "RIGHT" : "LEFT";
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }
    }

    public void Teleport(Vector3 vector){
        transform.localPosition = vector;
    }
}
