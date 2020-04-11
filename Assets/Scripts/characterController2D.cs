using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterController2D : MonoBehaviour
{
    [SerializeField] public LayerMask groundLayer;
    private Rigidbody2D playerRB;
    private CapsuleCollider2D playerCollider;
    bool stopChecking = false;
    // Start is called before the first frame update
    
    private void Awake() {
        playerRB = GetComponent<Rigidbody2D>();   
        playerCollider = GetComponent<CapsuleCollider2D>(); 
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!stopChecking) {
        Debug.Log(grounded());
        if(grounded()) {
            stopChecking = true;
            playerRB.bodyType = RigidbodyType2D.Static;
        }
        }
    }

    private bool grounded() {
        RaycastHit2D groundCheck = Physics2D.Raycast(
            playerRB.position,
            Vector2.down,
            (playerCollider.size.y / 4.0f) + 0.2f,
            groundLayer);

        Debug.DrawLine(transform.position, transform.position + Vector3.down * (0.2f + playerCollider.size.y / 4.0f), Color.green);
        return groundCheck.collider != null;
    }
}
