using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    Animator anim; Rigidbody2D rb; CharacterController2D controller; PlayerMovement movement; 
    public AudioSource hurtSound;
   public static int maxHealth = 6; public static int health =6; public int numHearts =3;
   public Image[] hearts;
   public Sprite fullHeart; public Sprite halfHeart; public Sprite emptyHeart;
   void Start(){
       health = maxHealth;
       anim = GetComponent<Animator>();
       rb = GetComponent<Rigidbody2D>();
       controller = GetComponent<CharacterController2D>();
       movement = GetComponent<PlayerMovement>();
   }
   void Update(){
       if(health < 0) health = 0;
       if(health > 6) health = 6;
        switch(health){
            case 0:
                for (int i =0; i<hearts.Length; i++)
                    hearts[i].sprite = emptyHeart;
                health = 6; SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                break;
            case 1:
                hearts[0].sprite = halfHeart;
                hearts[1].sprite = emptyHeart;
                hearts[2].sprite = emptyHeart;
                break;
            case 2:
                hearts[0].sprite = fullHeart;
                hearts[1].sprite = emptyHeart;
                hearts[2].sprite = emptyHeart;
                break;
            case 3:
                hearts[0].sprite = fullHeart;
                hearts[1].sprite = halfHeart;
                hearts[2].sprite = emptyHeart;
                break;
            case 4:
                hearts[0].sprite = fullHeart;
                hearts[1].sprite = fullHeart;
                hearts[2].sprite = emptyHeart;
                break;
            case 5:
                hearts[0].sprite = fullHeart;
                hearts[1].sprite = fullHeart;
                hearts[2].sprite = halfHeart;
                break;
            case 6:
                hearts[0].sprite = fullHeart;
                hearts[1].sprite = fullHeart;
                hearts[2].sprite = fullHeart;
                break;        
        }
    }
    void OnTriggerEnter2D (Collider2D collider){
        // Debug.Log("Collision Detected:" + collider.gameObject.tag);
        if(collider.gameObject.tag == "Enemy"){
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
   

