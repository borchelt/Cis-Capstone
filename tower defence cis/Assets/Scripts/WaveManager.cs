using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    //custome class for defining waves
    [System.Serializable]
    public class waveDef
    {
        //each wave has an enemy type, number of enemies, and a score limit
        // - score limits define how many enemies can be on the field before the next wave spawns
        // - each enemy contributes score, if the total score is under the score limit the next wave is spawned 
        public GameObject enemy;
        public int count;
        public int scoreLimit;
        public waveDef subWave;
    }

    //stuff for getting the score and spawning the waves
    GameObject[] targetList;
    public List<waveDef> levelLayout;
    public int currentScore;
    public int waveIndex = 0;

    // Update is called once per frame
    void Update()
    {
        checkWaveScore();
        waveManager();
    }

    //finds the current score of the scene
    void checkWaveScore()
    {
        currentScore = 0;
        targetList = GameObject.FindGameObjectsWithTag("enemy");

        foreach(GameObject enemy in targetList)
        {
            EnemyMovement scorefinder = enemy.GetComponent<EnemyMovement>();
            if(scorefinder!=null)
                currentScore += scorefinder.score;

        }
        
    }

    //if the current score is lower than the score limit, spawn the next wave
    void waveManager()
    {
        Debug.Log("currentScore: " + currentScore);
        Debug.Log("threshhold: " + levelLayout[waveIndex].scoreLimit);
        if (currentScore <= levelLayout[waveIndex].scoreLimit)
        {
            waveDef wave = levelLayout[waveIndex];
            spawnWave(wave);
        }
    }

    //spawns the wave, adds a random vector to each enemy to prevent stacking
    void spawnWave(waveDef wave)
    {
        for(int i = 1; i <= wave.count; i++)
        {
            GameObject enemyOBJ;
            Vector2 randomVector = new Vector2(Random.Range(-5.0f, 5.0f), Random.Range(-5.0f, 5.0f));
            // Enemy object is made in-game at the spawner XY coords + the random vector
            enemyOBJ = Instantiate(wave.enemy, new Vector2(transform.position.x + randomVector.x, transform.position.y + randomVector.y), Quaternion.identity);
        }

        //once the wave is spawned, move to the next wave
        if(waveIndex < levelLayout.Count-1)
            waveIndex++;
    }


}
