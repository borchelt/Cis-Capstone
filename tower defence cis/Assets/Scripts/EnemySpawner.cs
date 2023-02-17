using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // variables and objects set
    public GameObject enemy;

    //cooldown variable for spawning enemies 
    public float cd = 2.0f;

    // timer initiated for enemies
    void Start()
    {
        StartCoroutine(SpawnTimerEnemy());
    }

    // Update is called once per frame
    void Update()
    {
        SpawnTimerEnemy();
    }

    // to spawn an Enemy
    private void spawnEnemy()
    {
        // Game object set for XY spawning coords
        GameObject enemyOBJ;
        // Enemy object is made in-game at the spawner XY coords
        enemyOBJ = Instantiate(enemy, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
    }

    // timer for Enemies to spawn
    IEnumerator SpawnTimerEnemy()
    {
        while (true)
        {
            yield return new WaitForSeconds(cd);
            spawnEnemy();
        }
    }
}
