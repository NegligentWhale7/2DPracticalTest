using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> items = new();
    [SerializeField] private Transform[] spawnPoints = new Transform[0];
    [SerializeField] private float minItems = 1;
    [SerializeField] private float maxItems = 10;

    private void Awake()
    {
        for(int i = 0; i < Random.Range(minItems, maxItems); i++)
        {
            int randomItem = Random.Range(0, items.Count);
            int randomSpawnPoint = Random.Range(0, spawnPoints.Length);
            Instantiate(items[randomItem], spawnPoints[randomSpawnPoint].position, Quaternion.identity);
        }
    }
}
