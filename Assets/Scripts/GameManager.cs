using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public GameObject completeLevelUI; public GameObject health;
    public GameObject timeUI;
    Animator menuAnim;
    public float waitingTime = 3.0f;
    bool winGame = false;
    bool gameOver = false;
    void Start(){
        menuAnim = GameObject.Find("TransitionPanel").GetComponent<Animator>();
    }
    public void CompleteLevel()
    {
        completeLevelUI.SetActive(true);
        health.SetActive(false); timeUI.SetActive(false);
        if(winGame == false)
        {
            Invoke("Restart", waitingTime);
            winGame = true;
        }
        
    }
    public void Restart(){
        StartCoroutine(WaitingWin());
        // SceneManager.LoadScene(0);
    }
    public void GameOver()
    {
        StartCoroutine(WaitingGameOver());
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }
    private IEnumerator WaitingWin(){
        yield return new WaitForSeconds (1f);
        menuAnim.SetBool("animateOut",true);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(0);

    }
    private IEnumerator WaitingGameOver(){
        yield return new WaitForSeconds (1f);
        menuAnim.SetBool("animateOut",true);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);

    }

}
