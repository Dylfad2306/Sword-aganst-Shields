using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealth : MonoBehaviour
{
    public playerstatsscipt playerScript;
    public spawnenemy spawnenemy;
    public Text textElementHealth;
    public Text textElementEnemysLeft;
    public Text textElementTheRound;
    // Start is called before the first frame update
    void Start()
    {
        //enemyPerRounds
        textElementHealth.text = playerScript.PlayerHP.ToString();
        textElementEnemysLeft.text = spawnenemy.enemyPerRounds.ToString();
        textElementTheRound.text = spawnenemy.theRound.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        textElementHealth.text = playerScript.PlayerHP.ToString() + "Hp";
        textElementEnemysLeft.text = spawnenemy.enemyPerRounds.ToString() + "left";
        textElementTheRound.text = spawnenemy.theRound.ToString() + "Round";
    }
}
