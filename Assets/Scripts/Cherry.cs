using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cherry : MonoBehaviour
{
    Collider2D currentCollider;
    AudioSource audio;
    private void Start(){
        currentCollider = GetComponent<Collider2D>();
        audio = GameObject.Find("ChompSound").GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collider){

        if(collider.tag == "Player"){
            if(Health.health < 6){
                audio.Play();
                Health.health++;
                gameObject.SetActive(false);
            }
        }
    }
}
