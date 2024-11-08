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
        // Crear una lista de los puntos de spawn disponibles
        List<Transform> availableSpawnPoints = new List<Transform>(spawnPoints);

        int itemsToSpawn = Mathf.Min(availableSpawnPoints.Count, (int)Random.Range(minItems, maxItems));

        for (int i = 0; i < itemsToSpawn; i++)
        {
            // Seleccionar un punto de spawn aleatorio de los disponibles
            int randomSpawnIndex = Random.Range(0, availableSpawnPoints.Count);
            Transform spawnPoint = availableSpawnPoints[randomSpawnIndex];

            // Instanciar el item en el punto de spawn seleccionado
            int randomItemIndex = Random.Range(0, items.Count);
            Instantiate(items[randomItemIndex], spawnPoint.position, Quaternion.identity);

            // Remover el punto de spawn utilizado de la lista
            availableSpawnPoints.RemoveAt(randomSpawnIndex);
        }
    }
}
