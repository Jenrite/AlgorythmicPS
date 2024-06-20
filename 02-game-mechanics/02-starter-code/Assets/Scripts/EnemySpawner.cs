using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;





    public class EnemySpawner : MonoBehaviour
    {

        [System.Serializable]
        public class Wave
        {
            public Enemy enemyPrefab;
            public float spawnInterval = 2;
            public int maxEnemies = 20;
        }

        public UnityEvent OnWaveStarted = new UnityEvent();
        public float EnemySpawnDelay = 2f;
        public Enemy EnemyPrefab;
        public Transform[] waypoints;
        public List<Wave> waves; // The definition of all our waves (will be set in-editor)
        private int currentWaveIndex = 0;
        public int timeBetweenWaves = 5;
        public List<Enemy> enemies;

        // This is a cool Unity trick where you can define Start as a coroutine.
        // Unity will automatically run it as a coroutine when the game object starts.
        IEnumerator Start ()
        {
            while (currentWaveIndex < waves.Count)
                    {
                    OnWaveStarted?.Invoke(); // Fire an event that we'll hook into later.
                    for (var i = 0; i < waves[currentWaveIndex].maxEnemies; i++)
                    {
                        // Spawn an enemy, then wait for the spawn interval before continuing.
                        SpawnEnemy();
                        yield return new WaitForSeconds(waves[currentWaveIndex].spawnInterval);
                    }
                    // Increment the current wave index. You could also write a for loop rather than a while loop if you prefer.
                    currentWaveIndex++;
                    yield return new WaitForSeconds(timeBetweenWaves);
            }
        }

        public void SpawnEnemy()
        {
            Enemy newEnemy = Instantiate(waves[currentWaveIndex].enemyPrefab, transform.position, Quaternion.identity);
            enemies.Add(newEnemy);
            newEnemy.waypoints = waypoints;
        }
    }

