using UnityEngine;

public class EnemySpawnPoint : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public Transform EnemySpawner;

    public float spawnInterval = 5;
    private float timeSinceLastSpawn = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
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
            SpawnEnemy();
            timeSinceLastSpawn = 0;
        }
    }
    // Update is called once per frame
    private void SpawnEnemy()
    {
        int index = Random.Range(0,enemyPrefabs.Length);
        GameObject eGo = Instantiate(enemyPrefabs[index],EnemySpawner.position,Quaternion.identity);
        Enemy enemy = eGo.GetComponent<Enemy>();

        enemy.direction = Random.value > 0.5f ? 1 : -1;
    }
}
