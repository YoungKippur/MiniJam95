using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    public float interval = 2f;
    private Animator animator;
    private bool triggered;
    private float timer;

    void Start()
    {
        animator = GetComponent<Animator>();
        triggered = false;
        timer = interval;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0){
            if(!triggered) animator.SetBool("IsTriggered", true); 
            else animator.SetBool("IsTriggered", false);
            triggered = !triggered;
            timer = interval;
        }
    }
}
