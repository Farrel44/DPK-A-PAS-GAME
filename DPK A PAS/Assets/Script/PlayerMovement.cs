using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]


public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D body;
    private Animator anim;
    private bool Grounded = true;
    private float jumpRotation; 
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        float HorizontalInput = Input.GetAxis("Horizontal");

    if (Grounded)
        {
            jumpRotation = transform.rotation.eulerAngles.z;
        }

        body.velocity = new Vector3(HorizontalInput * speed, body.velocity.y);
        
        if(HorizontalInput > 0.01f){
            transform.localScale = new Vector3(1.5f,1.5f,1);
        }

        if(HorizontalInput < -0.01f){
            transform.localScale = new Vector3(-1.5f,1.5f,1);
        }

        if(Input.GetKey(KeyCode.Space) && Grounded){
            Jump();
        }

        anim.SetBool("run", HorizontalInput != 0);
        anim.SetBool("Grounded", Grounded);
    }
    private void Jump(){
        body.velocity = new Vector2(body.velocity.x, speed);
        Grounded = false;
    }
    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag == "Ground"){
            Grounded = true;
        }
    }
}
