using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public EnemyController[] enemiesToSpawn;
    public Transform spawnPoint;
    public float timeBetweenSpawns = 0.5f;
    public float spawnCounter;
    public int amountToSpawn = 15;


    // Start is called before the first frame update
    void Start()
    {
        spawnCounter = timeBetweenSpawns;
    }

    // Update is called once per frame
    void Update()
    {
        if(amountToSpawn > 0)
        {
            spawnCounter -= Time.deltaTime;
            if(spawnCounter <= 0 )
            {
                spawnCounter = timeBetweenSpawns;
                Instantiate(enemiesToSpawn[Random.Range(0, enemiesToSpawn.Length)], spawnPoint.position, spawnPoint.rotation);

                amountToSpawn -= 1;
            }
        }
    }
}
