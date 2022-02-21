using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerupPrefab;
    private float timePassedForPowerup;
    private float waitTime = 1.0f;
    private float waitForPowerup;
    private float timePassed;
    private float spawnRange = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        waitForPowerup = Random.Range(5.0f, 20.0f);
    }

    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime;
       
        if(timePassed >= waitTime)
        {
            Instantiate(enemyPrefab, GenerateRandomPos(), enemyPrefab.transform.rotation);
            timePassed = 0.0f;
            waitTime = Random.Range(2.0f, 5.0f);
        }

        timePassedForPowerup += Time.deltaTime;

        if (timePassedForPowerup >= waitForPowerup)
        {
            Instantiate(powerupPrefab, GenerateRandomPos(), powerupPrefab.transform.rotation);
            timePassedForPowerup = 0.0f;
            waitForPowerup = Random.Range(5.0f, 20.0f); 
        }
    }

    Vector3 GenerateRandomPos()
    {
        float x = Random.Range(-spawnRange, spawnRange);
        float y = Random.Range(-spawnRange, spawnRange);

        return new Vector3(x, 0, y);
    }
}
