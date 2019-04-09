using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MinionController : MonoBehaviour
{
    readonly Type TVoid = typeof(void);
    Function.Fn1V<GameObject> deregister;
    private float velocity;
    private Rigidbody rb;
    private int id;
    private float minX, minZ, maxX, maxZ;
    private float rotY;
    public void Init(Function.Fn1V<GameObject> deregister) {
        this.deregister = deregister;
    }   // Start is called before the first frame update
    void Start()
    {
        System.Random rand = new System.Random();
        rb = GetComponent<Rigidbody>();
        id = rand.Next();
        minX = minZ = 0f;
        maxX = maxZ = 50.0f;
        velocity = 5f + 2.5f * (float)rand.NextDouble();
        rotY = 45f + (float)(rand.NextDouble() * 90f);
        rb.transform.Rotate(0f, rotY, 0f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!InView()) {
            Destroy();  
        }
        rb.velocity = rb.transform.forward * this.velocity;
    }

    void Destroy() {
        if (this.deregister != null) {
            this.deregister(gameObject);
        }
        Destroy(gameObject);
    }

    bool InView() {
        if (rb.position.x > maxX || rb.position.x < minX ||
            rb.position.z > maxZ || rb.position.z < minZ) {
            return false;
        }
        return true;
    }
}