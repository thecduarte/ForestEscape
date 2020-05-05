using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    public CharacterController2D controller; 
    public Animator animator; 

    public float runSpeed = 40f;

    float horizontalMove = 0f;

    public bool jump = false;

    bool crouch = false;

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
       
        if (Input.GetButtonDown("Jump")){
            jump = true;
            animator.SetBool("IsJumping", true);
        }

        if (Input.GetButtonDown("Crouch")){
            crouch = true;
        }
        else if(Input.GetButtonUp("Crouch")){
            crouch = false; 
        }
    }
    
    public void OnLanding(){
        animator.SetBool("IsJumping", false);
    }

    public void OnCrounching(bool isCrouching){
        animator.SetBool("IsCrouching", isCrouching);
    }
    
    //Physics Update
    void FixedUpdate(){
        //Character Movement Here
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false; 
    }
}
