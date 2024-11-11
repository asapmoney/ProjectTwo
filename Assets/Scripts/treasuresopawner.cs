using UnityEngine;

public class TreasureSpawner : MonoBehaviour
{
    public GameObject treasurePrefab;
    public int numberOfTreasures = 10;
    public float spawnAreaSize = 50.0f;
    public float wallMargin = 2.0f;  

    void Start()
    {
        SpawnTreasures();
    }

    void SpawnTreasures()
    {
        for (int i = 0; i < numberOfTreasures; i++)
        {
            Vector3 randomPosition = GetValidSpawnPosition();
            Instantiate(treasurePrefab, randomPosition, Quaternion.identity);
        }
    }

    Vector3 GetValidSpawnPosition()
    {
        Vector3 randomPosition;
        bool isValid = false;

        do
        {
            
            randomPosition = new Vector3(
                Random.Range(-spawnAreaSize, spawnAreaSize),
                0,  
                Random.Range(-spawnAreaSize, spawnAreaSize)
            );

            
            if (Mathf.Abs(randomPosition.x) > spawnAreaSize - wallMargin &&
                Mathf.Abs(randomPosition.z) > spawnAreaSize - wallMargin)
            {
                isValid = false;
            }
            else
            {
                isValid = true;
            }
        }
        while (!isValid);

        return randomPosition;
    }
}
