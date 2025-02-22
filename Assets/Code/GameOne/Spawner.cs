using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WineCrafter
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private GameObject[] fallingObjects;

        private float x1, x2;
        private float minSpawnDelayStart = 0.5f; // minimum time between spawns
        private float minSpawnDelayEnd = 0.1f;
        private float maxSpawnDelay = 2f; // maximum time between spawns
        private float lastSpawnTime; // time of last spawn
        private Camera cam;


        void Awake()
        {

            cam = Camera.main;

            //set screen size as the size width of spawner for falling objects
            Vector2 topLeft = (Vector2)cam.ScreenToWorldPoint(new Vector3(100, cam.pixelHeight, cam.nearClipPlane));
            Vector2 topRight = (Vector2)cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth - 100, cam.pixelHeight, cam.nearClipPlane));

            x1 = topLeft.x;
            x2 = topRight.x;


            //Initialize lastSpawnTime to the current time
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


