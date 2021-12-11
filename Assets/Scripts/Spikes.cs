using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    public float interval = 2f;
    private Animator animator;
    private bool triggered;
    private bool daño;
    private float timer;

    void Start()
    {
        animator = GetComponent<Animator>();
        triggered = false;
        daño = false;
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
            Dañoo();
        }
    }

    void OnTriggerEnter2D(Collider2D collider){
        if (collider.gameObject.tag == "Player"){
            daño = true;
            Dañoo();
        }
    }
    void OnTriggerExit2D(Collider2D collider){
        if (collider.gameObject.tag == "Player"){
           daño = false;
           Dañoo();
        }
    }
    void Dañoo (){
        if (daño == true && triggered == true){
            Debug.Log("Daño");
        }
    }
}
