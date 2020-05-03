using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHurtBox : MonoBehaviour
{
    Collider2D currentCollider;
    // float currentTime;

    private bool hasCollide = false;
    void Start(){
        currentCollider = GetComponent<Collider2D>();
        // currentTime = GameObject.Find("Slider").GetComponent<TimeBar>().currentTime;
    }
    IEnumerator OnTriggerEnter2D(Collider2D collider){
        Debug.Log("Test:" + hasCollide);
        if(collider.tag == "Player"){
            if(hasCollide == false){
                // Debug.Log("I reached here!");
                hasCollide = true;
                currentCollider.enabled = false;
                Health.health--;
                yield return new WaitForSeconds (2);
                currentCollider.enabled = true;
                hasCollide = false;
            }
            // Debug.Log("Collision Detected");
            
            // yield return new WaitForSeconds (5);
            // currentCollider.enabled = true;
        }
    }
}
