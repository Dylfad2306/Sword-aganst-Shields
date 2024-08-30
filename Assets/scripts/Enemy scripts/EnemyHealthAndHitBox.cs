using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int EnemyHP = 2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            EnemyHP -= 1;
            Destroy(collision.gameObject);
            if (EnemyHP <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
