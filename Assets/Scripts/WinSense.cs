using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinSense : MonoBehaviour
{
    CoinCounter coinCounter; bool escape = false;
    Collider2D currentCollider; GameManager gameManager;
    void Start(){
        coinCounter = GameObject.Find("CoinCounter").GetComponent<CoinCounter>();
        currentCollider = GetComponent<Collider2D>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    void Update(){
        if(coinCounter.coinCount == 1) currentCollider.enabled = false; escape = true;
    }
    void OnTriggerEnter2D(Collider2D collider){
        if(collider.tag == "Player" && escape == true ){
            gameManager.CompleteLevel();
        }
    }
}
