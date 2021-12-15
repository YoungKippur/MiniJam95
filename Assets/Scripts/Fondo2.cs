using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fondo2 : MonoBehaviour{

    void Update()
    {
        if (Input.anyKey){
            Debug.Log("Ola");
            UnityEngine.SceneManagement.SceneManager.LoadScene("Game Creation");
        }
    }
}
