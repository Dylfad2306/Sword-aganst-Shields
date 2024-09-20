using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealth : MonoBehaviour
{
    public playerstatsscipt playerScript;
    public spawnenemy spawnenemy;
    public Shoot_Misile Shoot_Misile;
    public Text textElementHealth;
    public Text textElementEnemysLeft;
    public Text textElementTheRound;
    public Text textElementRocketCooldown;
    private float cdTrue;
    // Start is called before the first frame update
    void Start()
    {
        //enemyPerRounds
        textElementHealth.text = playerScript.PlayerHP.ToString();
        textElementEnemysLeft.text = spawnenemy.enemyPerRounds.ToString();
        textElementTheRound.text = spawnenemy.theRound.ToString();
        textElementRocketCooldown.text = Shoot_Misile.cd.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        textElementHealth.text = playerScript.PlayerHP.ToString() + "Hp";
        textElementEnemysLeft.text = spawnenemy.enemyPerRounds.ToString() + "left";
        textElementTheRound.text = spawnenemy.theRound.ToString() + "Round";
        cdTrue = MathF.Round(Shoot_Misile.cd, 2);
        textElementRocketCooldown.text = cdTrue.ToString() + "seconds";
    }
}
