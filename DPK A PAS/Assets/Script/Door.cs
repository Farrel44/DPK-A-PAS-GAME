using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public bool locked;

    private Animator anim;

    Scene activeScene = SceneManager.GetActiveScene();
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        locked = true;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject Player = GameObject.FindWithTag("Player");
        float distance = Vector2.Distance(Player.transform.position, transform.position);

        if(!locked){
            anim.SetTrigger("Open");
        }
        else{
            anim.SetTrigger("Close");
        }
        
        Scene activeScene = SceneManager.GetActiveScene();
        Debug.Log(activeScene.buildIndex);

        if(!locked && distance < 0.5f){ 
            //index : 
            //level 1 (2)
            //level 2 (3)
            //level 3 (4)
            //level 4 (5)
            //level 5 (6)
            SceneManager.LoadScene(activeScene.buildIndex + 1);
            Debug.Log(activeScene.buildIndex + 1);
        }
        
    }



    private void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.CompareTag("Key")){
            locked = false;
        }
    }

    private void OnTriggerExit2D(Collider2D other){
        if(other.gameObject.CompareTag("Key")){
            locked = true;
        }
    }

}
