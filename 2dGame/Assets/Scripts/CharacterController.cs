using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class CharacterController : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float jumpForce = 5f;
    private Rigidbody2D _rigidboyd2D;
    private Animator _animator;
    private bool grounded;
    private bool started;
    private bool jumping;
    private void Awake()
    {
        _rigidboyd2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        grounded = true;
        
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
           if (started && grounded)
            {
                _animator.SetTrigger(name:"Jump");
                grounded= false;
                jumping = true;
                
            }
            else
            {
                _animator.SetBool(name: "GameStarted", true);
                started = true;
            } 
        }
        
        
           _animator.SetBool("Grounded", true);
        
    }
    private void FixedUpdate()
    {
        if (started==true)
        {
            _rigidboyd2D.velocity = new Vector2(speed, _rigidboyd2D.velocity.y);
        }
        if(jumping==true) 
        { 
            _rigidboyd2D.AddForce(new Vector2(0f, jumpForce));
            jumping = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")) 
        {
            grounded = true;
        }
        
    }
}
