using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTP : MonoBehaviour
{
    GameObject Player, EndTeleport;

    void Start(){
        EndTeleport = GameObject.Find("End");
        Player = GameObject.Find("Player");
    }

    void OnTriggerEnter2D(Collider2D collider){
        if (collider.gameObject.tag == "Player"){
            Debug.Log("TP");
            Player.transform.localPosition = EndTeleport.transform.localPosition;
        }
    }
}
