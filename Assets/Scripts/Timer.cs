using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Animator animator;
    GameObject Player;
    public Text UItexto;
    private int contador = 0;

    void Start(){
        Player = GameObject.Find("Player");
        Player.transform.localPosition = new Vector3(20,20,0);
    }

    private void Awake(){
        InvokeRepeating("Cronometro", 0f, 1f);
    }

    void Cronometro(){
        contador++;
        if (contador == 20){
            Player.transform.localPosition = new Vector3(-6.5f,-1.5f,0f);
            UItexto.text = "PLAYER 2 PLAY" + " " + (contador - 20).ToString();
            animator.SetBool("IsBlock", true);
        }
        if (contador > 20){
            UItexto.text = "PLAYER 2 PLAY" + " " + (contador - 20).ToString();
        }
        if (contador < 20){
            Player.transform.localPosition = new Vector3(20,20,0);
            UItexto.text = contador.ToString();
        }
    }
}
