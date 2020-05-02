using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillBox : MonoBehaviour
{
   void OnTriggerEnter2D(Collider2D collision)
   {
       if(collision.gameObject.tag == "Player")
       {
            // FindObjectOfType<GameManager>().GameOver();
           Application.LoadLevel(Application.loadedLevel);
       }
   }
}
