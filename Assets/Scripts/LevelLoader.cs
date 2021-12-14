using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoaderr : MonoBehaviour{

    public Animator tramsition; 
    public float transitionT = 1f;

    void Update()
    {
        if (Input.anyKey){
            Debug.Log("Ola");
            LoadNextLevel();
        }
    }

    public void LoadNextLevel(){
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }   

    IEnumerator LoadLevel(int levelIndex){
        tramsition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionT);
        SceneManager.LoadScene(levelIndex);
    }
}