using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    Animator animator;
    void Start(){
        animator = GameObject.Find("TransitionPanel").GetComponent<Animator>();
    }
    public void PlayGame(){
        StartCoroutine(Waiting());
    }
    public void QuitGame(){
        Debug.Log("Game Quit.");
        Application.Quit();
    }
    private IEnumerator Waiting(){
        animator.SetBool("animateOut", true);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);

    }
}
