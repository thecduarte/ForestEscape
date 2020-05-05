using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public GameObject completeLevelUI;
    public GameObject health;
    public GameObject timeUI;
    Animator menuAnim;
    private float waitingTime = 1f;
    bool winGame = false;
    void Start(){
        menuAnim = GameObject.Find("TransitionPanel").GetComponent<Animator>();
    }
    public void ForestEscape(){
        completeLevelUI.SetActive(true);
    }
    public void CompleteLevel()
    {
        health.SetActive(false); timeUI.SetActive(false);
        if(winGame == false)
        {
            Invoke("Restart", waitingTime);
            winGame = true;
        }
    }
    public void Restart(){
        StartCoroutine(WaitingWin());
    }
    public void GameOver()
    {
        StartCoroutine(WaitingGameOver());
    }
    private IEnumerator WaitingWin(){
        menuAnim.SetBool("animateOut",true);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(4); //This is the Win Scene.
    }
    private IEnumerator WaitingGameOver(){
        yield return new WaitForSeconds (2f);
        menuAnim.SetBool("animateOut",true);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
