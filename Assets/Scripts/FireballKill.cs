using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballKill : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
            {
                 if (collision.gameObject.tag == "Ground")
                 {
                    Debug.Log("Ground Touched.");
                    Destroy(this.gameObject);
                 }
                 if(collision.gameObject.tag == "Player")
                    Application.LoadLevel(Application.loadedLevel);
            }
}
