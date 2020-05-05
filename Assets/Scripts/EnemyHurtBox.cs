using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHurtBox : MonoBehaviour
{
    Collider2D currentCollider;
    private bool hasCollide = false;
    void Start(){
        currentCollider = GetComponent<Collider2D>();
    }
    IEnumerator OnTriggerEnter2D(Collider2D collider){
        if(collider.tag == "Player"){
            if(hasCollide == false){
                hasCollide = true;
                currentCollider.enabled = false;
                Health.health--;
                yield return new WaitForSeconds (2);
                currentCollider.enabled = true;
                hasCollide = false;
            }
        }
    }
}
