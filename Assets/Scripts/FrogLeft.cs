using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogLeft : MonoBehaviour
{
    private float leftCap, rightCap;
    
    [SerializeField] private float jumpLength = 2.5f;
    [SerializeField] private float jumpHeight = 3.6f;
    [SerializeField] private LayerMask ground;
    private Collider2D collider;
    private Rigidbody2D rigidbody;

    private Animator anim;
    private bool facingLeft = true;
    
    private void Start(){
        collider = GetComponent<Collider2D>();
        rigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        leftCap = transform.position.x - 10;
        rightCap = transform.position.x - 1f;
    }
    private void Update(){
        //Transition from Jump to Fall 
        if(anim.GetBool("Jumping")){
            if(rigidbody.velocity.y < 0.1){
                anim.SetBool("Falling", true);
                anim.SetBool("Jumping", false);
            }
        }
        //Transition from Fall to Idle
        if(collider.IsTouchingLayers(ground) && anim.GetBool("Falling")){
            anim.SetBool("Falling",false);
        }

    }
    private void Move()
    {
        if (facingLeft)
        {
            //Left Cap Beyond Test
            if (transform.position.x > leftCap)
            {
                //Make sure sprite is facing correct location, if not, face correct direction. 
                if (transform.localScale.x != 0.85f)
                {
                    transform.localScale = new Vector3(0.85f, 0.85f);
                }
                //Test to see if on ground, if so jump.
                if (collider.IsTouchingLayers(ground))
                {
                    //Jump
                    rigidbody.velocity = new Vector2(-jumpLength, jumpHeight);
                    anim.SetBool("Jumping", true);
                
                }
            }
            else facingLeft = false;
        }
        else
        {
            if (transform.position.x < rightCap)
            {
                //Make sure sprite is facing correct location, if not, face correct direction. 
                if (transform.localScale.x != -0.85f)
                {
                    transform.localScale = new Vector3(-0.85f, 0.85f);
                }
                //Test to see if on ground, if so jump.
                if (collider.IsTouchingLayers(ground))
                {
                    //Jump
                    rigidbody.velocity = new Vector2(jumpLength, jumpHeight);
                    anim.SetBool("Jumping", true);
                }
            }
            else facingLeft = true;
        }
    }
}
