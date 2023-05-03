using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    //custome class for defining waves
    [System.Serializable]
    public class waveDef
    {
        //each wave has an enemy type, number of enemies, and a time limit limit
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
        //lower the cooldown
        levelLayout[waveIndex].timeWait -= Time.deltaTime;
        //deal with the waves
        waveManager();
    }

    //manages the waves
    void waveManager()
    {
        Debug.Log("threshhold: " + levelLayout[waveIndex].timeWait);

        //spawns the wave on cooldown and moves to the next one
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

    //getDistance uses a random vector but makes sure it isnt too close to 0
    Vector2 getDistance()
    {
        //either multiply the final value by 1 or -1
        int flipVal = 1;
        if(Random.value > .5)
        {
            flipVal = -1;
        }
        float xDist;
        float yDist;
        
        //get the random x and y coordinates 
        xDist = Random.Range(0, spawnMaxDistance);
        yDist = Random.Range(0, spawnMaxDistance);

        //if too close to 0, set the values to the minimum value
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

        //flip the vectors to add negative options 
        return new Vector2(xDist*flipVal, yDist*flipVal);



    }


}
