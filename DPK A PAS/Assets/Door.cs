using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public bool locked;

    private Animator anim;
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

        if(!locked && distance < 0.5f){ 
            StartCoroutine(LoadNextScene());
        }
        
    }

    IEnumerator LoadNextScene(){
        yield return new WaitForSeconds(0.25f);
        SceneManager.LoadScene("level 2");
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
