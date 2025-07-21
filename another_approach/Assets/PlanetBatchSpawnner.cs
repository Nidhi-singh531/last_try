using UnityEngine;
using System.Collections.Generic;

public class PlanetBatchSpawner : MonoBehaviour
{
    public GameObject[] spawnPrefabs; // 3 normal + 1 danger
    public Transform spawnOrigin;     // Where spawning starts
    public float spacing = 5f;

    private int lastIndex = -1;

    public void SpawnThreePlanets()
    {
        float baseX = spawnOrigin.position.x;

        for (int i = 0; i < 3; i++)
        {
            int index;
            do
            {
                index = Random.Range(0, spawnPrefabs.Length);
            } while (index == lastIndex);

            lastIndex = index;

            Vector3 spawnPos = new Vector3(baseX + i * spacing, spawnOrigin.position.y, 0);
            Instantiate(spawnPrefabs[index], spawnPos, Quaternion.identity);
        }

        // Move the spawner forward by 3 * spacing
        spawnOrigin.position = new Vector3(baseX + 3 * spacing, spawnOrigin.position.y, spawnOrigin.position.z);
    }
}
