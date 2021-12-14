using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fondo : MonoBehaviour{

    void Update()
    {
        if (Input.anyKey){
            Debug.Log("Ola");
            UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
        }
    }
}