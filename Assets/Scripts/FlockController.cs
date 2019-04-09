using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockController : MonoBehaviour
{
    class TargetLocation {
        Vector3 location;
        float weight;
    }
    private float avoidanceRadius;
    private float flockRadius;
    private Rigidbody[] neighbors;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /** SEPARATION */
    /**
     Requests game objects that are too close to itself to
     Move further away
     */
    void requestSeparate() {

    }

    /** ALIGNMENT */
    /**
     Calculates the alignment of its neighbors, using the average of
     their rotations
     */
    void calculateAlignment() {

    }

    /** Cohesion */
    /**
    Attempts to calculate the point where it should move towards so
    that it minimizes the distance between it and its neighbors
     */
    void minimizeDistance() {

    }

    /**
    Given a set of vectors and their weights, calculate where the boid
    should go
     */
    Vector3 vectorControl(TargetLocation[] targetLocations) {
        return Vector3.zero;
    }
}