using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButton : MonoBehaviour
{
    Animator animator;
    private bool estado = false;

    void Start(){
        animator = GetComponent<Animator>();
    }

    public void OnButtonPress(){
        estado = !estado;
        if (estado == true){
            animator.SetBool("isPress", true);
        }
        else animator.SetBool("isPress", false);
    }
    
}
