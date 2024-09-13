using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float EnemyHP = 2;


    playerstatsscipt playerStats;
    // Start is called before the first frame update
    void Start()
    {
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<playerstatsscipt>();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            EnemyHP -= playerStats.playerDamage;
            Destroy(collision.gameObject);
            if (EnemyHP <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
