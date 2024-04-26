using UnityEngine;
using System.Collections;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject objectToSpawn;
    public float spawnRangeXMin = -10f; 
    public float spawnRangeXMax = 10f; 
    public int numberOfObjects = 10; 
    public float spawnInterval = 0.2f; 

    void Start()
    {
        StartCoroutine(SpawnObjects());
    }

    IEnumerator SpawnObjects()
    {
        for (int i = 0; i < numberOfObjects; i++)
        {
            
            float randomX = Random.Range(spawnRangeXMin, spawnRangeXMax);

            
            Vector2 randomPosition = new Vector2(randomX, transform.position.y);

            
            GameObject newObject = Instantiate(objectToSpawn, randomPosition, Quaternion.identity);

            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
