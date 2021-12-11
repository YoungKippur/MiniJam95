using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTP : MonoBehaviour
{
    public GameObject Player, EndTeleport;

    void OnTriggerEnter2D(Collider2D collider){
        if (collider.gameObject.tag == "Player"){
            Debug.Log("TP");
            Player.transform.position = new Vector2(EndTeleport.transform.position.x, EndTeleport.transform.position.y);
        }
    }
}
