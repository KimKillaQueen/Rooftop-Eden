using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jump_action : MonoBehaviour
{
    [Range(1.0f, 10.0f)]
    [SerializeField] public float jumpVelocity = 1.0f;

    [Range(1.0f, 3.0f)]
    [SerializeField] public float fallMultiplier = 2.5f;
    
    [Range(1.0f, 3.0f)]
    [SerializeField] public float lowJumpMultiplier = 2.0f;
    // []
    // Start is called before the first frame update
    public void invoke(ref Rigidbody2D playerRB, bool isGrounded, bool isJumping) {
        if(playerRB.velocity.y < 0.0f) {
            playerRB.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.fixedDeltaTime;
        } else if(playerRB.velocity.y > 0.0f && !Input.GetButton("Jump")) {
            playerRB.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.fixedDeltaTime;
        } else if(isJumping) {
            playerRB.velocity = Vector2.up * jumpVelocity + Vector2.right * playerRB.velocity.x;
        }
    }

    public void FixedUpdate() {
        // if()
    }
}
