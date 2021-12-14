using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour{

    public Animator tramsition; 
    public float transitionT = 1f;

    public void LoadNextLevel(){
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }   

    IEnumerator LoadLevel(int levelIndex){
        tramsition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionT);
        SceneManager.LoadScene(levelIndex);
    }

}