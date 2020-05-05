using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    // float currentTime;
    GameManager gameManager; bool refresh = true;
    public PlayerMovement playerMovement; public CharacterController2D controller2D;
    public Animator anim; public Rigidbody2D rb; public CharacterController2D controller; public PlayerMovement movement; 
    public AudioSource hurtSound;
   public static int maxHealth = 6; public static int health =6; public int numHearts =3;
   public Image[] hearts;
   public Sprite fullHeart; public Sprite halfHeart; public Sprite emptyHeart;
   void Start(){
       health = maxHealth;
       gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
   }
   void Update(){
       Debug.Log("Health Value" + health);
       if(health < 0) health = 0; 
       if(health > 6) health = 6; 
        switch(health){
            case 0:
                for (int i =0; i<hearts.Length; i++)
                    hearts[i].sprite = emptyHeart;
                health = 6; refresh = false; 
                anim.SetTrigger("Hurting");
                anim.SetBool("notHurting", false);
                controller2D.enabled = false;
                playerMovement.enabled = false;
                rb.constraints = RigidbodyConstraints2D.FreezePosition;
                Destroy(this.gameObject);
                gameManager.GameOver(); //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                break;

            case 1:
                if(refresh != false){
                    hearts[0].sprite = halfHeart;
                    hearts[1].sprite = emptyHeart;
                    hearts[2].sprite = emptyHeart;
                }
                break;
            case 2:
                if(refresh != false){
                    hearts[0].sprite = fullHeart;
                    hearts[1].sprite = emptyHeart;
                    hearts[2].sprite = emptyHeart;
                }
                break;
            case 3:
                if(refresh != false){
                    hearts[0].sprite = fullHeart;
                    hearts[1].sprite = halfHeart;
                    hearts[2].sprite = emptyHeart;
                }
                break;
            case 4:
                if(refresh != false){
                    hearts[0].sprite = fullHeart;
                    hearts[1].sprite = fullHeart;
                    hearts[2].sprite = emptyHeart;
                }
                break;
            case 5:
                if(refresh != false){
                    hearts[0].sprite = fullHeart;
                    hearts[1].sprite = fullHeart;
                    hearts[2].sprite = halfHeart;
                }
                break;
            case 6:
                if(refresh != false){
                    hearts[0].sprite = fullHeart;
                    hearts[1].sprite = fullHeart;
                    hearts[2].sprite = fullHeart;
                }               
                break;        
        }
    }
    void OnTriggerEnter2D (Collider2D collider){
        // Debug.Log("Collision Detected:" + collider.gameObject.tag);
        if(collider.gameObject.tag == "Enemy"){
            // Debug.Log("Current Time: " + currentTime);
            anim.SetTrigger("Hurting");
            StartCoroutine("Hurt");
        }
    }
    IEnumerator Hurt(){
        rb.velocity = Vector2.zero;
        hurtSound.Play(0);
        if(movement.jump != true){
            if(controller.m_FacingRight)
                rb.AddForce (new Vector2(-500f, 300f));
            else
                rb.AddForce(new Vector2(500f, 300f));
        }
        // else{
        //     if(controller.m_FacingRight)
        //         rb.AddForce (new Vector2(-200f, 200f));
        //     else
        //         rb.AddForce(new Vector2(200f, 200f));
        // }
        yield return new WaitForSeconds(0.5f);
    }
}
   

