using UnityEngine;

public class SuperJump : MonoBehaviour
{
    public float superJumpForce = 2f;

    public void Jump()
    {
        Rigidbody2D body = GetComponent<Rigidbody2D>();
        if (body != null)
        {
            body.velocity = new Vector2(body.velocity.x, superJumpForce * PlayerMovement.speed);
            PlayerMovement.Grounded = false;
        }
    }
}
