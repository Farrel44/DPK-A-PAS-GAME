using UnityEngine;

public class ladderMovement : MonoBehaviour
{
    private float speed = 6f;
    public AudioSource audioSource;
    public AudioClip useLadder;

    private bool isMoving = false; 

    void Start()
    {

    }

    void Update()
    {

    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {

            float verticalInput = Input.GetAxis("Vertical");
            Rigidbody2D playerRigidbody = other.GetComponent<Rigidbody2D>();
            playerRigidbody.velocity = new Vector2(0, verticalInput * speed);
            isMoving = Mathf.Abs(verticalInput) > 0;
            if (isMoving && !audioSource.isPlaying)
            {
                audioSource.PlayOneShot(useLadder);
            }
            else if ((!isMoving || Mathf.Abs(verticalInput) < 0.01f) && audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }
}
