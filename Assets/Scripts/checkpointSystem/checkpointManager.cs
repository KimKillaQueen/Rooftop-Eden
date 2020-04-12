using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpointManager : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Transform> checkPoints;
    private int lastVisitedCheckPointIndex = 0;
    void Start()
    {
        checkPoints.AddRange(GetComponentsInChildren<Transform>());
        checkPoints.Remove(transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Transform findCheckpoint() {
        return checkPoints[lastVisitedCheckPointIndex];
    }

    public List<Transform> getCheckPoints() {
        return checkPoints;
    }

    public void setLatestCheckpoint(Transform checkpoint) {
        int newIndex = checkPoints.FindIndex(0, checkPoints.Count, x => x == checkpoint);
        if(newIndex > lastVisitedCheckPointIndex) {
            lastVisitedCheckPointIndex = newIndex;
        }
    }
}
