using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{   
    public GameObject PointA1;
    public GameObject PointA2;
    private Rigidbody2D rb2;
    private Animator anim;
    private Transform CurrentPoint;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        CurrentPoint = PointA2.transform;
        anim.SetBool("Is_Running", true);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 point = CurrentPoint.position - transform.position;
        if(CurrentPoint == PointA2.transform){
            rb2.velocity = new Vector2(speed, 0);
        }
        else{
            rb2.velocity = new Vector2(-speed, 0);
        }

        

        if(Vector2.Distance(transform.position, CurrentPoint.position) < 0.5f && (CurrentPoint == PointA2.transform)){
            flip();
            CurrentPoint = PointA1.transform;
        }
        if(Vector2.Distance(transform.position, CurrentPoint.position) < 0.5f && (CurrentPoint == PointA1.transform)){
            flip();
            CurrentPoint = PointA2.transform;
        }

    }

    private void flip(){
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    private void OnDrawGizmos(){
            Gizmos.DrawWireSphere(PointA1.transform.position, 0.5f);
            Gizmos.DrawWireSphere(PointA2.transform.position, 0.5f);
            Gizmos.DrawLine(PointA1.transform.position, PointA2.transform.position);
        }    
}
