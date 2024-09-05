using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class spawnenemy : MonoBehaviour
{
    public Vector3 spawnPoint = new Vector3(0, 5, 0);
    public GameObject baseEnemy;
    public GameObject ironEnemy; //Tank
    public GameObject goldEnemy; //Speedy
    public GameObject diamondEnemy; //50% more health
    public GameObject netheriteEnemy; // Boss and 100% more health,damage and 25% slower 
    private int spawnChance;
    private int normalOrSpecial;
    public double enemyPerRounds = 5; // kan inte vara float för att den andra är double
    public double enemyPerRoundsMath = 5; // Varför inte en float
    public float bossesLeftThisRound = 1;
    public float theRound = 1;
    private float letThereBeCards = 1;
    public bool isThereAEnemyLeft = true;
    public CardSelectionManager cardSelectionManager;

    bool startingRound = false;

    float timeToSpawn = 0;
    public float spawnDelay = 5f;// in secends

    private void Shoot()
    {
        if(timeToSpawn >= Time.time)
        {
            // do shooting code here
            timeToSpawn = Time.time + spawnDelay;
        }

    }


    enum levelState
    {
        enemySpawning,
        bossSpawning,

    }

    // Update is called once per frame
    IEnumerator WaitAndPrint()
    {
        // suspend execution for 5 seconds
        yield return new WaitForSeconds(5);

        theRound++;
        enemyPerRoundsMath = enemyPerRoundsMath * 1.5;
        enemyPerRoundsMath = Math.Round(enemyPerRoundsMath, MidpointRounding.AwayFromZero);
        enemyPerRounds = enemyPerRoundsMath;
        bossesLeftThisRound++;
        startingRound = false;
        letThereBeCards = 1;
    }

    void SpawnEnemies()
    {
        int rInt = UnityEngine.Random.Range(-8, 8);
        spawnPoint = new Vector3(rInt, 5, 0);
        int normalOrSpecial = UnityEngine.Random.Range(0, 100);
        if (normalOrSpecial >= 0 && normalOrSpecial <= 40)
        {
            int whatSpecial = UnityEngine.Random.Range(0, 100);
            if (whatSpecial >= 0 && whatSpecial <= 49)
            {
                //Tank / iron enemy
                GameObject tank = Instantiate(ironEnemy, spawnPoint, Quaternion.identity);
                enemyPerRounds -= 1;
            }
            else if (whatSpecial >= 50 && whatSpecial <= 80)
            {
                //Speedy / Gold enemy
                GameObject speedy = Instantiate(goldEnemy, spawnPoint, Quaternion.identity);
                enemyPerRounds -= 1;
            }
            else if (whatSpecial >= 81 && whatSpecial <= 100)
            {
                //Heavy / Diamond enemy
                GameObject heavy = Instantiate(diamondEnemy, spawnPoint, Quaternion.identity);
                enemyPerRounds -= 1;
            }
        }
        else
        {
            GameObject normal = Instantiate(baseEnemy, spawnPoint, Quaternion.identity);
            enemyPerRounds -= 1;
        }
    }

    void SpawnBoss()
    {
        int rInt = UnityEngine.Random.Range(-8, 8);
        spawnPoint = new Vector3(rInt, 5, 0);
        GameObject boss = Instantiate(netheriteEnemy, spawnPoint, Quaternion.identity);
        bossesLeftThisRound--;
    }

    void Update()
    {
        if (enemyPerRounds > 0)
        {
            isThereAEnemyLeft = true;
        }
        int spawnChance = UnityEngine.Random.Range(0, 100);
        if (spawnChance == 2 && enemyPerRounds > 0 && isThereAEnemyLeft == true || Input.GetKeyDown(KeyCode.F))
        {
            SpawnEnemies();
        }  
        if (enemyPerRounds <= 0 && bossesLeftThisRound == 1)
        {
            SpawnBoss();
        }
        GameObject enemy = GameObject.FindGameObjectWithTag("Enemy");
        if (enemy == null)
        {
            isThereAEnemyLeft = false;
        }
        if (bossesLeftThisRound == 0 && isThereAEnemyLeft == false)
        {
            if (letThereBeCards == 1)
            {
                // add start card selection
                cardSelectionManager.StartCardSelection(OnCardSelectionComplete);
                letThereBeCards = 0;
                
            }
            else if(cardSelectionManager.isCardsDun == true)
                {
                Debug.Log("tta me merbi agen");
                if (!startingRound)
                {
                    print("hello ita a me merbio");
                    startingRound = true;
                    StartCoroutine("WaitAndPrint");
                }
            }

        }
    }
    void OnCardSelectionComplete()
    {
    }


}