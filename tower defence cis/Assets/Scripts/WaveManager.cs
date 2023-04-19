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
        public float timeWait;
    }

    //stuff for getting the score and spawning the waves
    public float spawnMaxDistance;
    public float spawnMinDistance;
    public List<waveDef> levelLayout;
    public int waveIndex = 0;
    bool lastWave = false;

    // Update is called once per frame
    void Update()
    {
        levelLayout[waveIndex].timeWait -= Time.deltaTime;
        waveManager();
    }

    //finds the current score of the scene
    //void checkWaveScore()
    //{
     //   currentScore = 0;
     //   targetList = GameObject.FindGameObjectsWithTag("enemy");
     //
     //   foreach(GameObject enemy in targetList)
     //   {
     //      EnemyMovement scorefinder = enemy.GetComponent<EnemyMovement>();
     //       if(scorefinder!=null)
     //           currentScore += scorefinder.score;

     //   }
        
    //}

    //if the current score is lower than the score limit, spawn the next wave
    void waveManager()
    {
        Debug.Log("threshhold: " + levelLayout[waveIndex].timeWait);
        if (levelLayout[waveIndex].timeWait <= 0 && !lastWave)
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
            Vector2 randomVector = getDistance();
            // Enemy object is made in-game at the spawner XY coords + the random vector
            enemyOBJ = Instantiate(wave.enemy, new Vector2(transform.position.x + randomVector.x, transform.position.y + randomVector.y), Quaternion.identity);
        }

        //once the wave is spawned, move to the next wave
        if (waveIndex < levelLayout.Count - 1)
            waveIndex++;
        else if (waveIndex >= levelLayout.Count - 1)
        {
            lastWave = true;
            return;
        }
            
    }

    Vector2 getDistance()
    {
        int flipVal = 1;
        if(Random.value > .5)
        {
            flipVal = -1;
        }
        float xDist;
        float yDist;
        
        xDist = Random.Range(-spawnMaxDistance, spawnMaxDistance);
        yDist = Random.Range(-spawnMaxDistance, spawnMaxDistance);

        if (xDist < spawnMinDistance && yDist < spawnMinDistance)
        {
            if(Random.value > .5)
            {
                xDist = spawnMinDistance;
            }
            else
            {
                yDist = spawnMinDistance;
            }
        }

        return new Vector2(xDist*flipVal, yDist*flipVal);



    }


}
