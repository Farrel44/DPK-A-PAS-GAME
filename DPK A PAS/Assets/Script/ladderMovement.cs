using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ladderMovement : MonoBehaviour
{
    private float speed = 6f;

    void Start() 
    {
        
    }
    void Update()
    {
    
    }

    private void OnTriggerStay2D(Collider2D other) {
        if (other.tag == "Player" && Input.GetKey(KeyCode.W)){
            other.GetComponent<Rigidbody2D>().velocity = new Vector2 (0,speed);
        }
        else if (other.tag == "Player" && Input.GetKey(KeyCode.S)){
            other.GetComponent<Rigidbody2D>().velocity = new Vector2 (0,-speed);
        }
    }
    
}
