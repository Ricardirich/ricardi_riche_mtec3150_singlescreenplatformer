using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    public GameObject[] powerUpPrefabs;   
    public Transform spawnPoint;          

    public float spawnInterval = 10f;
    private float timeSinceLastSpawn = 0f;

    private void Start()
    {
        
        timeSinceLastSpawn = spawnInterval;
    }

    private void Update()
    {
        if (timeSinceLastSpawn < spawnInterval)
        {
            timeSinceLastSpawn += Time.deltaTime;
        }
        else
        {
            SpawnPowerUp();
            timeSinceLastSpawn = 0f;
        }
    }

    private void SpawnPowerUp()
    {
        if (powerUpPrefabs.Length == 0) return;

        int index = Random.Range(0, powerUpPrefabs.Length);
        GameObject go = Instantiate(powerUpPrefabs[index], spawnPoint.position, Quaternion.identity);

        
        go.transform.rotation = Quaternion.identity;
    }
}