using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class Wave
{
    public string waveName;
    public int noEnemies;
    public GameObject[] typeEnemies;
    public float waveDelay;
}

public class SpawnManager : MonoBehaviour
{
    private DoorFunc doorFunc;

    public Wave[] waves;
    public List<GameObject> spawnPoints = new List<GameObject>();
    private List<GameObject> tempRandomPoint = new List<GameObject>();
    private Wave currentWave;
    private int currentWaveNumber;
    private bool canSpawnStart = true;
    private bool canSpawn = false;
    private float waveDelayTimer = 0;

    void Awake()
    {
        doorFunc = GetComponent<DoorFunc>();
    }

    void Update()
    {
        currentWave = waves[currentWaveNumber];

        Timers();

        SpawnWave();

        GameObject[] totalEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (totalEnemies.Length == 0 && !canSpawn && currentWaveNumber + 1 != waves.Length)
        {
            if (waveDelayTimer >= currentWave.waveDelay && !canSpawnStart)
            {
                currentWaveNumber++;

                canSpawn = true;
            }
            else if (waveDelayTimer >= currentWave.waveDelay && canSpawnStart)
            {
                canSpawn = true;

                canSpawnStart = false;
            }
        }

        if (totalEnemies.Length == 0 && !canSpawn && currentWaveNumber + 1 == waves.Length)
        {
            doorFunc.UnlockDoors();
        }
    }

    void Timers()
    {
        if (waveDelayTimer < currentWave.waveDelay)
        {
            waveDelayTimer += Time.deltaTime;
        }
    }

    void SpawnWave()
    {
        if (canSpawn)
        {
            GameObject randomEnemy = currentWave.typeEnemies[Random.Range(0, currentWave.typeEnemies.Length)];

            int randomPointNum = Random.Range(0, spawnPoints.Count);
            GameObject randomPoint = spawnPoints[randomPointNum];

            Instantiate(randomEnemy, randomPoint.transform.position, Quaternion.identity);

            tempRandomPoint.Add(randomPoint);

            spawnPoints.RemoveAt(randomPointNum);

            currentWave.noEnemies--;
            if (currentWave.noEnemies == 0)
            {
                for (int i = 0; i < tempRandomPoint.Count; i++)
                {
                    spawnPoints.Add(tempRandomPoint[i]);
                }

                tempRandomPoint.Clear();

                waveDelayTimer = 0;

                canSpawn = false;
            }
        }
    }
}
