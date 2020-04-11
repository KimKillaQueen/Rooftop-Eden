using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement_action : action
{
    [SerializeField] public float acceleration = 3.0f;
    // Start is called before the first frame update
    public void invoke(float direction, ref Rigidbody2D playerRB, bool isGrounded) {
        // if(isGrounded) {
            Debug.Log("moving");
            playerRB.velocity += Vector2.right * acceleration * direction * Time.fixedDeltaTime;
        // }
    }
}
