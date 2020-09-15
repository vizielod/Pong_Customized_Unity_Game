using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostSpawner : MonoBehaviour
{
    public GameObject[] boosts;
    public float spawnInterval = 20f; //0.9493672
    private float timer;

    public bool hasStarted;

    // Start is called before the first frame update
    void Start()
    {
        //beat = beat / 60f;
    }

    // Update is called once per frame
    void Update()
    {
        if (hasStarted)
        {
            if (timer > spawnInterval)
            {
                int random = Random.Range(0, 10); //Boost object pool
                Vector3 randomSpawnPosition = new Vector3(0, Random.Range(-15f, +15f), 0); //Randomize Spawning position in x=0 y=(-15,15)

                Debug.Log(random);
                GameObject boost = Instantiate(boosts[random], randomSpawnPosition, Quaternion.identity);

                timer -= spawnInterval;
            }

            timer += Time.deltaTime;
        }

    }
}
