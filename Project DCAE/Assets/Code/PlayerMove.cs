using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public ControlType controlType;
    public Joystick joystick; 
    public float speed;
    public enum ControlType{PC, Android}

    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Vector2 moveVelocity;
    private Animator anim;
    private bool facingRight = true;
    private void Start()
    {
        if(controlType == ControlType.PC)
        {
            joystick.gameObject.SetActive(false);
        }

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        if(controlType == ControlType.PC)
        {
            moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")); // He see move player & moveInput with keyboard
        }

        else if(controlType == ControlType.Android)
        {
            moveInput = new Vector2(joystick.Horizontal, joystick.Vertical); // He see move player & moveInput with help joystick
        }
        
        if(Input.GetKey(KeyCode.LeftShift))
        {
            moveVelocity = moveInput.normalized * speed * 1.5f; // He give speed 
        }

        else
        {
             moveVelocity = moveInput.normalized * speed;
        }

        if(!facingRight && moveInput.x > 0)
        {
            Flip(); // if player turn right, but look left - Flip
        }

        else if(facingRight && moveInput.x < 0)
        {
            Flip(); // if player turn left, but look right - Flip
        }
        {

        }

        if(moveInput.x == 0)
        {
            anim.SetBool("isWalking", false); // Animation stay
        }

        else
        {
            anim.SetBool("isWalking", true); // Animation walk
        }
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime); // He rotate position player
    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
