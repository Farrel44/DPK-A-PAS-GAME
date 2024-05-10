using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorFinish : MonoBehaviour
{
    public bool locked;
    private Animator anim;

    [SerializeField] public GameObject ending;

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
            //index : 
            //level 1 (2)
            //level 2 (3)
            //level 3 (4)
            //level 4 (5)
            //level 5 (6)
            SceneManager.LoadScene("start scene");
            ending.SetActive(true);
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
