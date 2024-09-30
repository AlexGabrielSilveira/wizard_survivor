using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public List<Transform> spawnPoints;
    public List<Sprite> sprites;
    public List<Transform> enemies;
    float spawn_cooldown = 10f;
    void Start()
    {
        SpawnEnemies();
    }
    private void Update()
    {
        spawn_cooldown -= Time.deltaTime;
       if (spawn_cooldown <= 0)
        {
            SpawnEnemies();
        }
    }
    void SpawnEnemies()
    {
        spawn_cooldown = 10f;
        foreach (var spawn in spawnPoints) 
        {
            var random_index = Random.Range(0, enemies.Count);
            Instantiate(enemies[random_index], spawn.position, Quaternion.identity);
        }
    }
}
