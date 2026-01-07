using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;
public class EnemySpawner : MonoBehaviour
{
    [System.Serializable]
    public class Wave
    {
        public GameObject enemyPrefab;
        public float spawnTimer;
        public float spawnInterval;
        public int enemiesPerWave;
        public int spawnedEnemyCount;
    }

    public List<Wave> waves;  //lists all waves 
    public int waveNumber; //current  wave index 
    public Transform minPos;
    public Transform maxPos;

    // Update is called once per frame
    void Update()
    {
        if (PlayerController.Instance.gameObject.activeSelf)
        {
            waves[waveNumber].spawnTimer += Time.deltaTime; //spawn timer increase 
            if (waves[waveNumber].spawnTimer >= waves[waveNumber].spawnInterval) //spawn check for new enemy 
            {
                waves[waveNumber].spawnTimer = 0; //resets timer 
                SpawnEnemy(); //call spawn function 
            }
            if (waves[waveNumber].spawnedEnemyCount >= waves[waveNumber].enemiesPerWave) //wave complete or not 

            {
                waves[waveNumber].spawnedEnemyCount = 0; //reset
                if (waves[waveNumber].spawnInterval > 0.3f) //increase difficulty option 
                {
                    waves[waveNumber].spawnInterval *= .9f;
                }
                waveNumber++; //next wave 
            }
            if (waveNumber >= waves.Count) //loop finish code
            {
                waveNumber = 0;
            }
        }
    }
  
        private void SpawnEnemy()
    {
        Instantiate(waves[waveNumber].enemyPrefab, RandomSpawnPoint(), transform.rotation); //spawns enemies
        waves[waveNumber].spawnedEnemyCount++; //spawn counter increase 
    }
    private Vector2 RandomSpawnPoint()
    {
        Vector2 spawnPoint;

        if (Random.Range(0f, 1f) > 0.5)
        {
            spawnPoint.x = Random.Range(minPos.position.x, maxPos.position.x);
            if (Random.Range(0f, 1f) > 0.5)
            {
                spawnPoint.y = minPos.position.y;
            }
            else
            {
                spawnPoint.y = maxPos.position.y;
            }
        }
        else
        {
            spawnPoint.y = Random.Range(minPos.position.y, maxPos.position.y);
            if (Random.Range(0f, 1f) > 0.5)
            {
                spawnPoint.x = minPos.position.x;
            }
            else
            {
                spawnPoint.x = maxPos.position.x;
            }
        }


        return spawnPoint;
    }
}
