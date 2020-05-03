using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeBar : MonoBehaviour
{
    public float currentTime = 0f; public float startingTime = 180f;
    
    public GameObject player; 
    // public GameObject[] enemies;
    // Rigidbody2D[] rbEnemies;
    // Animator[] animEnemies;
    GameManager gameManager;
    Rigidbody2D rbPlayer;
   
    Animator animPlayer;
    PlayerMovement movement;
    GameObject health;
    public GameObject timeUpUI;
    public Slider slider;
    public Text displayText;
    private float currentValue = 1f;
    void Awake(){
        rbPlayer = player.GetComponent<Rigidbody2D>();
        animPlayer = player.GetComponent<Animator>();
        movement = player.GetComponent<PlayerMovement>();
        health = GameObject.Find("Health");
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

    }
    public float CurrentValue{
        get{
            return currentValue;
        }
        set{
            currentValue = value;
            slider.value = currentValue;
            displayText.text = (slider.value*startingTime).ToString("0") + "s";
        }
    }
    
    void Start(){
        currentTime = startingTime;
        CurrentValue = 1f;
    }
    void Update(){
        currentTime -= 1 * Time.deltaTime;
        CurrentValue -= Time.deltaTime/startingTime;
        if(slider.value == 0){
            animPlayer.enabled = false;
            rbPlayer.constraints = RigidbodyConstraints2D.FreezePosition;
            movement.enabled = false;
            health.SetActive(false);
            timeUpUI.SetActive(true);
            StartCoroutine(TimeUp());
        }
    }
    IEnumerator TimeUp(){
        yield return new WaitForSeconds(3);
        gameManager.Restart();
        // SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
