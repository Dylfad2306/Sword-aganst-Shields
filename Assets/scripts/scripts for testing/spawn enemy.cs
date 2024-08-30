using System;
using System.Collections;
using System.Collections.Generic;
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
    public bool isThereAEnemyLeft = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyPerRounds > 0)
        {
            isThereAEnemyLeft = true;
        }
        int spawnChance = UnityEngine.Random.Range(0, 100);
        if (spawnChance == 2 && enemyPerRounds > 0 && isThereAEnemyLeft == true || Input.GetKeyDown(KeyCode.F))
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
                else if(whatSpecial >= 50 && whatSpecial <= 80)
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
        if (enemyPerRounds <= 0 && bossesLeftThisRound == 1)
        {
            int rInt = UnityEngine.Random.Range(-8, 8);
            spawnPoint = new Vector3(rInt, 5, 0);
            GameObject boss = Instantiate(netheriteEnemy, spawnPoint, Quaternion.identity);
            bossesLeftThisRound--;
        }
        GameObject enemy = GameObject.FindGameObjectWithTag("Enemy");
        if (enemy == null)
        {
            isThereAEnemyLeft = false;
        }
        if (bossesLeftThisRound == 0 && isThereAEnemyLeft == false)
        {
            theRound++;
            enemyPerRoundsMath = enemyPerRoundsMath * 1.5;
            enemyPerRoundsMath = Math.Round(enemyPerRoundsMath, MidpointRounding.AwayFromZero);
            enemyPerRounds = enemyPerRoundsMath;
            bossesLeftThisRound++;
        }
    }
}