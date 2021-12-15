using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTP : MonoBehaviour{
    GameObject Player, EndTeleport;
    Animator animator;
    private bool portal = false, portal2 = false;
    private float timer;
    public float interval = 2f;

    void Start(){
        EndTeleport = GameObject.Find("End");
        Player = GameObject.Find("Player");
        animator = Player.GetComponent<Animator>();
        timer = interval;
    }

    void Update(){
        EndTeleport = GameObject.Find("EndTeleport");
        Player = GameObject.Find("Player");
        if (portal){
            timer -= Time.deltaTime;
            if(timer <= 0){
                Debug.Log("TP");
                Player.transform.localPosition = EndTeleport.transform.localPosition;
                timer = interval;
                animator.SetBool("isPortal", false);
                animator.SetBool("isPortal2", true);
                portal2 = true;
            }
        }
        else if (portal2){
            timer -= Time.deltaTime;
            if(timer <= 0){
                timer = interval;
                animator.SetBool("isPortal2", false);
                portal2 = false;
            }
        }
        else timer = interval;
    }

    void OnTriggerEnter2D(Collider2D collider){
        if (collider.gameObject.tag == "Player"){
            portal = true;
            animator.SetBool("isPortal", true);
            animator.SetBool("isRunning", false);
        }
    }

    void OnTriggerExit2D(Collider2D collider){
        if (collider.gameObject.tag == "Player"){
            portal = false;
            animator.SetBool("isPortal", false);
            timer = interval;
        }
    }
}
