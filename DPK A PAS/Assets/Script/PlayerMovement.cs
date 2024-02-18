using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D body;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float HorizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector3(HorizontalInput * speed, body.velocity.y);
        
        //flip player when move left and right
        if(HorizontalInput > 0.01f){
            transform.localScale = new Vector3(1.5f,1.5f,1);
        }

        if(HorizontalInput < -0.01f){
            transform.localScale = new Vector3(-1.5f,1.5f,1);
        }

        if(Input.GetKey(KeyCode.Space)){
            body.velocity = new Vector2(body.velocity.x, speed);
        }
    }
}
