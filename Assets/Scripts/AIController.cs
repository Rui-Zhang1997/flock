using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AIController : MonoBehaviour {
    private GameObject leader;
    private Rigidbody rb;
    void Awake() {
        rb = GetComponent<Rigidbody>();
        leader = rb.gameObject;
    }
    void Start() {

    }

    GameObject GameObjectFromCollider(Collider c) {
        return c.attachedRigidbody.gameObject;
    }
    void FixedUpdate() {
        Vector3 location = rb.position;
        float scanDistance = 2.5f;
        Collider[] colliders = Physics.OverlapSphere(location, 2.5f);
        GameObject[] gameObjects = FP.Map<Collider, GameObject>(Physics.OverlapSphere(location, scanDistance),
                                                                GameObjectFromCollider);
    }
}