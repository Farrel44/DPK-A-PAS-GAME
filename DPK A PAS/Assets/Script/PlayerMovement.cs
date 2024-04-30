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

    [SerializeField] ParticleSystem dieParticle;
    SpriteRenderer spriteRenderer;
    Vector2 startPosititon;
    public AudioSource source;
    public AudioClip clip;
    [SerializeField] public AudioClip run, hitGorund, jumpGorund, idle, DieSound, useLadder;
    [SerializeField] public static float speed = 6f;
    public Rigidbody2D body;
    private Animator anim;
    public static bool Grounded = true;
    private float jumpRotation; 
    
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        startPosititon = transform.position;
    }

    void Update()
    {

        float HorizontalInput = Input.GetAxis("Horizontal");

    if (Grounded)
        {
            jumpRotation = transform.rotation.eulerAngles.z;
        }

        body.velocity = new Vector3(HorizontalInput * speed, body.velocity.y);

        if (Mathf.Approximately(HorizontalInput, 0f) && Grounded && !source.isPlaying)
        {
            source.PlayOneShot(idle);
        }
        
        if (!Mathf.Approximately(HorizontalInput, 0f) && Grounded && !source.isPlaying)
        {
            source.PlayOneShot(run);
            anim.SetBool("run", true);
        }

        else
        {
            anim.SetBool("run", false);
        }

        if(HorizontalInput > 0.01f){
            transform.localScale = new Vector3(1.1f,1.1f,1);
        }

        if(HorizontalInput < -0.01f){
            transform.localScale = new Vector3(-1.1f,1.1f,1);
        }


        if(Input.GetKey(KeyCode.Space) && Grounded){
            Jump();
            source.PlayOneShot(clip);

        }

        anim.SetBool("run", Mathf.Abs(HorizontalInput) > 0.01f);
        anim.SetBool("Grounded", Grounded);
    }
    protected virtual void Jump(){
        body.velocity = new Vector2(body.velocity.x, speed * 2);
        Grounded = false;
    }
    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag == "Ground"){
            Grounded = true;
            source.PlayOneShot(hitGorund);
        }
        else if(collision.gameObject.tag == "laser"){
            source.PlayOneShot(DieSound);
            die();
        }
    }

    IEnumerator respawn(float duration){
        body.simulated = false;
        spriteRenderer.enabled = false;
        transform.localScale = new Vector3(0,0,0);
        yield return new WaitForSeconds(duration);
        transform.position = startPosititon;
        transform.localScale = new Vector3(1,1,1);
        body.simulated = true;
        spriteRenderer.enabled = true;

    }

    void die(){
        StartCoroutine(respawn(0.5f));
        dieParticle.Play(); 
    }
    
}
public class superJump : PlayerMovement{
    protected override void Jump(){
        body.velocity = new Vector2(body.velocity.x, speed * 3);
        Grounded = false;
    }

}
