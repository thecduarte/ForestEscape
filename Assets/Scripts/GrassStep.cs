using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassStep : MonoBehaviour
{
    AudioSource grassStep;
    Rigidbody2D rigidBody;
    bool falling = false;
    void Awake()
    {
        Debug.Log("This Activates.");
        grassStep = GameObject.Find("GrassStepSound").GetComponent<AudioSource>();
        rigidBody = GameObject.Find("Player").GetComponent<Rigidbody2D>();
    }
    // void FixedUpdate(){
    //     if(rigidBody.velocity.y < -5) falling = true;
    // }

    private void OnTriggerEnter2D(Collider2D collision)
    {   
        if(collision.gameObject.tag == "Player")
        {
            grassStep.Play();  
            falling = false;  
        }
        
    }
}
