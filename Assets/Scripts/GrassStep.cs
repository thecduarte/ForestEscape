using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassStep : MonoBehaviour
{
    AudioSource grassStep;
    void Awake()
    {
        Debug.Log("This Activates.");
        grassStep = GameObject.Find("GrassStepSound").GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {   
        if(collision.gameObject.tag == "Player")
        {
            grassStep.Play();    
        }
        
    }
}
