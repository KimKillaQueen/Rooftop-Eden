using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawnPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject checkPointManager;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "runner") {
            // FindObjectOfType<checkpointManager>().findCheckpoint();
            other.gameObject.transform.position = FindObjectOfType<checkpointManager>().findCheckpoint().position;
            Debug.Log("respawning");
            other.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            // Transform respawnPoint = checkPointManager.findCheckpoint();
        }
    }
}
