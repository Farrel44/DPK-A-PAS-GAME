using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    PlayerMovement playerMovement;
    // Start is called before the first frame update
    private void Awake(){
        GameObject playerObject = GameObject.FindWithTag("Player"); 
        if (playerObject != null)
        {
            playerMovement = playerObject.GetComponent<PlayerMovement>(); 
            Debug.LogError("GameObject with tag 'Player' found!!");
        }
        else
        {
            Debug.LogError("No GameObject with tag 'Player' found!");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("Player")){
            playerMovement.UpdateCheckPoint(transform.position);
        }
    }
}
