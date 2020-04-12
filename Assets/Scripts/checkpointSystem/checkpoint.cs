using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpoint : MonoBehaviour
{
    // Start is called before the first frame update
private void OnTriggerEnter2D(Collider2D other)
{
    if(other.gameObject.tag == "runner") {
        Debug.Log("Checkpoint found");
        GetComponentInParent<checkpointManager>().setLatestCheckpoint(transform);
    }
}
}
