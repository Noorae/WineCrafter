using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*namespace WineCrafter
{
    public class Spawner : MonoBehaviour
    {

        [SerializeField] private GameObject[] fallingObjects;

        private BoxCollider2D col;

        float x1, x2;


        // Start is called before the first frame update
        void Awake()
        {
            col = GetComponent<BoxCollider2D>();

            x1 = transform.position.x - col.bounds.size.x / 2f;
            x2 = transform.position.x + col.bounds.size.x / 2f;


        }

        // Update is called once per frame
        void Start()
        {
            StartCoroutine(Spawn(0.01f));

        }

        IEnumerator Spawn(float time)
        {

            yield return new WaitForSecondsRealtime(time);

            Vector3 temp = transform.position;
            temp.x = Random.Range(x1, x2);
            if (Time.timeScale != 0f)
            {
                Instantiate(fallingObjects[Random.Range(0, fallingObjects.Length)], temp, Quaternion.identity);
            }

            
            StartCoroutine(Spawn(Random.Range(0.01f, 1.5f)));

        }
    }
}*/

namespace WineCrafter
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private GameObject[] fallingObjects;
        private BoxCollider2D col;
        private float x1, x2;
        private float minSpawnDelayStart = 0.5f; // minimum time between spawns
        private float minSpawnDelayEnd = 0.1f;
        private float maxSpawnDelay = 2f; // maximum time between spawns
        private float lastSpawnTime; // time of last spawn

        // Start is called before the first frame update
        void Awake()
        {
            col = GetComponent<BoxCollider2D>();
            x1 = transform.position.x - col.bounds.size.x / 2f;
            x2 = transform.position.x + col.bounds.size.x / 2f;

            // Initialize lastSpawnTime to the current time
            lastSpawnTime = Time.time;
        }

        // Update is called once per frame
        void Update()
        {
            // Calculate time since last spawn
            float timeSinceLastSpawn = Time.time - lastSpawnTime;

            // Check if enough time has passed to spawn a new object
            if (timeSinceLastSpawn >= minSpawnDelayStart)
            {
                // Calculate random wait time between spawns
                float spawnDelay = Random.Range(minSpawnDelayStart, maxSpawnDelay);

                // Start coroutine to spawn a new object after the wait time
                StartCoroutine(SpawnAfterDelay(spawnDelay));

                // Update last spawn time
                lastSpawnTime = Time.time;

                // Reduce maximum spawn delay to make objects spawn more frequently over time
                maxSpawnDelay = Mathf.Max(maxSpawnDelay - 0.01f, minSpawnDelayEnd);
            }
        }

        IEnumerator SpawnAfterDelay(float delay)
        {
            yield return new WaitForSecondsRealtime(delay);

            // Spawn a new object
            Vector3 spawnPos = transform.position;
            spawnPos.x = Random.Range(x1, x2);
            Instantiate(fallingObjects[Random.Range(0, fallingObjects.Length)], spawnPos, Quaternion.identity);
        }
    }
}


