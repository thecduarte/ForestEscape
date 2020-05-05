using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    private AudioSource audio;
    private Animator animator;
    public float delay = 5f;
    // Start is called before the first frame update
    void Start()
    {
        animator = GameObject.Find("TransitionPanel").GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
        audio.PlayDelayed(0.5f);
        Invoke("LoadStartMenu", delay);
    }
    void LoadStartMenu()
    {
        StartCoroutine(Waiting());
    }
     private IEnumerator Waiting(){
        animator.SetBool("animateOut", true);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(0);

    }
   
}
