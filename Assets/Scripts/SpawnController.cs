using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SpawnController : MonoBehaviour
{
    // Start is called before the first frame update
    public int maxSpawns; // maxUnits allowed in scene at once
    public int spawnRate; // minions/sec
    private double minX, minZ, maxX, maxZ;
    private int spawns;
    private long lastSpawn;
    private System.Random rand;
    public Transform minion;
    private UnityEngine.Object prefabMinion;

    void Awake() {
        rand = new System.Random();
        minX = 0;
        minZ = 0;
        maxX = 50;
        maxZ = 50;
        spawns = 0;
        lastSpawn = 0;
        prefabMinion = Resources.Load("Prefabs/Minion");

        if (maxSpawns == 0) {
            maxSpawns = 100;
        }
        if (spawnRate == 0) {
            spawnRate = 5;
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        double xRange = maxX - minX;
        double zRange = maxZ - minZ;
        if(spawns < maxSpawns) {
            double pX = 0;
            double pZ = minZ + zRange * rand.NextDouble();
            SpawnMinion(pX, pZ);
            spawns += 1;
        }
    }

    public void DeregisterMinion(GameObject minion) {
        this.spawns -= 1;
    }

    void SpawnMinion(double pX, double pZ) {
        GameObject minion = Instantiate(prefabMinion, new Vector3((float)pX, 0.0f, (float)pZ), Quaternion.identity) as GameObject;
        MinionController controller = minion.GetComponent<MinionController>();
        controller.Init(this.DeregisterMinion);
    }
}
