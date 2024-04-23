using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManager : MonoBehaviour
{
    [SerializeField] GameObject Player;

    // Start is called before the first frame update

    public bool isPickedUp;
    public Vector2 vel;
    public float smoothTime;
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isPickedUp){
            Vector3 offset = new Vector3(0, 0, 0);
            transform.position = Vector2.SmoothDamp(transform.position, Player.transform.position + offset, ref vel, smoothTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.CompareTag("Player") && !isPickedUp){
            isPickedUp = true;
            Debug.Log("True");
        }
    }
}
