using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject[] goEnemyTypes = new GameObject[1];
    public GameObject[] goWeapons = new GameObject[3];
    public GameObject[] goRemaining;
    public Stats playerStats;
    public int iWaveNumber = 1;
    public int iEnemyCount;
    int iRandomSpawn;
    

    void Start()
    {
        //spawn first enemy
        iRandomSpawn = Random.Range(0, 3);
        Instantiate(goEnemyTypes[iRandomSpawn], new Vector3(Random.Range(-20, 20), Random.Range(1, 5), Random.Range(-20, 20)), Quaternion.identity); //random space in terrain
        //spawn first weapon
        iRandomSpawn = Random.Range(0, 3);
        Instantiate(goWeapons[iRandomSpawn], new Vector3(Random.Range(-20, 20), Random.Range(1, 5), Random.Range(-20, 20)), Quaternion.identity);
    }

    void Update()
    {
        goRemaining = GameObject.FindGameObjectsWithTag("Enemy");
        iEnemyCount = goRemaining.Length;
        if (goRemaining.Length == 0)
        {
            StartCoroutine(NextWave());
        }
    }

    IEnumerator NextWave()
    {
        yield return new WaitForSeconds(5);
        if (playerStats.bSpeedBuffed == true)
        {
            playerStats.bSpeedBuffed = false;
            playerStats.SpeedBuff();
        }
        if (playerStats.bJumpBuffed == true)
        {
            playerStats.bJumpBuffed = false;
            playerStats.JumpBuff();
        }
        if (goRemaining.Length == 0)
        {
            iWaveNumber++;
            for (int i = 0; i < iWaveNumber; i++)
            {
                int iRandomSpawn = Random.Range(0, 3);
                Instantiate(goEnemyTypes[iRandomSpawn], new Vector3(Random.Range(-20, 20), Random.Range(1, 5), Random.Range(-20, 20)), Quaternion.identity); //random space in terrain
            }
            int iRandomWeapon = Random.Range(0, 100);
            if (iWaveNumber % 2 == 0)
            {
                if (iRandomWeapon < 33)
                    Instantiate(goWeapons[0], new Vector3(Random.Range(-20, 20), Random.Range(1, 5), Random.Range(-20, 20)), Quaternion.identity);
                else if (iRandomWeapon > 33 && iRandomWeapon < 66)
                    Instantiate(goWeapons[1], new Vector3(Random.Range(-20, 20), Random.Range(1, 5), Random.Range(-20, 20)), Quaternion.identity);
                else
                    Instantiate(goWeapons[2], new Vector3(Random.Range(-20, 20), Random.Range(1, 5), Random.Range(-20, 20)), Quaternion.identity);
            }
        }
    }
}
