using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinSenseLeft : MonoBehaviour
{
    CoinCounter coinCounter; bool escape = false;
    GameObject leftArrow, rightArrow;
    Collider2D currentCollider; GameManager gameManager;
    void Start(){
        coinCounter = GameObject.Find("CoinCounter").GetComponent<CoinCounter>();
        currentCollider = GetComponent<Collider2D>();
        if(leftArrow = GameObject.Find("leftarrow")) leftArrow.SetActive(false);
        // if((rightArrow = GameObject.Find("rightarrow")) && rightCount == 0) rightArrow.SetActive(false); rightCount++;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    void Update(){
        if(coinCounter.coinCount == 10) {
            currentCollider.enabled = false; escape = true;
            leftArrow.SetActive(true); 
            // if(rightCount > 0) rightArrow.SetActive(true);
        }
    }
    void OnTriggerEnter2D(Collider2D collider){
        if(collider.tag == "Player" && escape == true ){
            gameManager.CompleteLevel();
        }
    }
}
