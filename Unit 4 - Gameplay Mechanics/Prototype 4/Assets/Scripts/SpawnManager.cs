using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    private float spawnRange = 9;
    public int enemyCount;
    public int waveNumber;
    public GameObject[] powerUpPrefabs;

    // Start is called before the first frame update
    void Start()
    {
        spawnEnemyWave(waveNumber);
        int randomPowerUp = Random.Range(0, powerUpPrefabs.Length);
        Instantiate(powerUpPrefabs[randomPowerUp], GenerateSpawnPosition(), powerUpPrefabs[randomPowerUp].transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if (enemyCount == 0)
        {
            waveNumber++;
            spawnEnemyWave(waveNumber);
            int randomPowerUp = Random.Range(0, powerUpPrefabs.Length);
            Instantiate(powerUpPrefabs[randomPowerUp], GenerateSpawnPosition(), powerUpPrefabs[randomPowerUp].transform.rotation);
        }
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;
    }

    private void spawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            int enemyType = Random.Range(0, enemyPrefabs.Length);
            Instantiate(enemyPrefabs[enemyType], GenerateSpawnPosition(), enemyPrefabs[enemyType].transform.rotation);
        }
    }
}
