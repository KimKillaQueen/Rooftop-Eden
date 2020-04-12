using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallrun_action : action
{
    // Start is called before the first frame update
    [SerializeField] public float wallRunForce = 300.0f;
    private bool canWallRun = true;
    public void invoke(Rigidbody2D playerRB, bool isNextToWall, bool isJumping, bool isGrounded, bool canWallRun)
    {
        if (isNextToWall && isJumping)
        {
            if (canWallRun)
            {
                canWallRun = false;
                playerRB.AddForce(Vector2.up * wallRunForce);
            }
        }
    }
}
