using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Week3PlayerScript : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D body;
    private Animator anim;
    public bool grounded;
    [SerializeField] private GameObject particleSystem;
   
    
    private void Awake()
    {   
        //Grabs references for rigidbody and animator from game object.
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    
    private void Start()
    {
        particleSystem.SetActive(true);
    }
    
    private void Update()
    {

        if (!grounded)
        {
            particleSystem.SetActive(false);
        }
        //if player is not in the air, set particle system to active
        if (grounded)
        {
            particleSystem.SetActive(true);
        }
        
        
        if (body.velocity.y < 0)
        {
            anim.SetTrigger("fall");
        }
        
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);
 
        //Flip player when facing left/right.
        if (horizontalInput > 0.01f)
            transform.localScale = new Vector3(1,1,1);
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-1, 1, 1);
 
        
        
        if (Input.GetKey(KeyCode.Space) && grounded)
        {
            Jump();
        }
            
 
        //sets animation parameters
        anim.SetBool("run", horizontalInput != 0);
        anim.SetBool("grounded", grounded);
    }
    
    //detect if player is falling

  
        
 
    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, speed);
        anim.SetTrigger("jump");
        grounded = false;
        particleSystem.SetActive(false);
    }
 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
            particleSystem.SetActive(false);
            // anim.SetTrigger("grounded");
        }
            
            
    }
}