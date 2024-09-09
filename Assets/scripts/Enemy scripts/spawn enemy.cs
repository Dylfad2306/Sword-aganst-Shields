using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public enum levelState
{
    enemySpawning,
    bossSpawning,
    showCards,
    startRound,
}

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
    public CardSelectionManager cardSelectionManager;
    public float spawnDelay = 5f;// in secends

    bool waitForStateChange = false;

    levelState currentState = levelState.enemySpawning;


    /*

Own method for changing state?
Would like to easily just iterate over state, but not sure if thats possible


States needs 3 things;
- Doing
- Checking for change
- Waiting

    Update()
    {
        if(!waitForStateChange)
        {
            // Do stuff
            // Spawn enemies until done
            // Spawn boss
            // show cards
            // start next round
        }
    }

    // It is really only the enemies that need to be in update
    // Instead have it in a coroutine or similar?

*/

    IEnumerator StateChangeDelay()
    {
        waitForStateChange = true;
        // suspend execution for 5 seconds
        yield return new WaitForSeconds(2);
        waitForStateChange = false;
        StartState();
    }

    public void ChangeState(levelState state, bool delay = true)
    {
        currentState = state;
        if (delay)
            StartCoroutine(StateChangeDelay());
        else
            StartState();
    }

    void StartState()
    {
        switch (currentState)
        {
            case levelState.bossSpawning: SpawnBoss(); break;
            case levelState.showCards: ShowCards(); break;
            case levelState.startRound: StartNewRound(); break;

            default: break;
        }
    }

    void StartNewRound()
    {
        theRound++;
        enemyPerRoundsMath = enemyPerRoundsMath * 1.5;
        enemyPerRoundsMath = Math.Round(enemyPerRoundsMath, MidpointRounding.AwayFromZero);
        enemyPerRounds = enemyPerRoundsMath;
        ChangeState(levelState.enemySpawning, false); // Change state without delay to enemySpawning
    }

    void SpawnEnemy()
    {
        // Use this to create a delay between spawning
        // if(timeToSpawn >= Time.time)
        // {
        //     // Code for spawning here
        //     timeToSpawn = Time.time + spawnDelay;
        // }

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
    }

    void SpawnBoss()
    {
        int rInt = UnityEngine.Random.Range(-8, 8);
        spawnPoint = new Vector3(rInt, 5, 0);
        GameObject boss = Instantiate(netheriteEnemy, spawnPoint, Quaternion.identity);
        // Could potentially use this to add a callback to the Boss component instead of using FindGameObjectWithTag
        bossesLeftThisRound--;
    }

    void ShowCards()
    {
        cardSelectionManager.StartCardSelection(OnCardSelectionComplete);
    }

    void Update()
    {
        if (!waitForStateChange)
        {
            if (currentState == levelState.enemySpawning)
            {
                if (enemyPerRounds > 0)
                    SpawnEnemy();
                else
                {
                    // Alternative to this is to have an int that keeps tabs on number of enemies spawned
                    // When an enemy dies, it sends a "-1" and this component checks if number of enemies is 0

                    GameObject enemy = GameObject.FindGameObjectWithTag("Enemy");
                    if (enemy == null)
                    {
                        // All enemies are dead, change state to boss
                        ChangeState(levelState.bossSpawning);
                    }
                }
            }
        }
    }

    // To change state from Boss state, inside boss component, where the boss "dies":
    /*
        GameObject stateMachine = GameObject.FindGameObjectWithTag("StateMachine"); // Use tag StateMachine on this GameObject
        stateMachine.GetComponent<StateMachine>().ChangeState(levelState.showCards); // StateMachine is the name of this component
    */

    // This method is called when the card has been selected
    void OnCardSelectionComplete()
    {
        ChangeState(levelState.startRound);
    }
}