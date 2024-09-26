using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot_Misile : MonoBehaviour
{
    public GameObject RocketPrefab;
    public GameObject ExplotionPrefab;
    private float RocketCooldown = 10;
    public Transform RocketMuzzle;
    private float RocketSpeed = 10f;
    public float cd;
    GameObject Rocket;

    private void OnDestroy()
    {
        GameObject Explotion = Instantiate(ExplotionPrefab, RocketMuzzle.position, Quaternion.identity);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && RocketCooldown <= Time.time)
        {
            GameObject Rocket = Instantiate(RocketPrefab, RocketMuzzle.position, Quaternion.identity);
            Rigidbody2D RocketRb = Rocket.GetComponent<Rigidbody2D>();

            Vector2 RocketVelocity = RocketMuzzle.up * RocketSpeed;
            RocketRb.velocity = RocketVelocity;

            RocketCooldown = RocketCooldown + Time.time;

            Destroy(Rocket, 2f);
        }
        cd = RocketCooldown - Time.time;

        if (cd < 0)
        {
            cd = 0;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            print("hello its a me marbio and you hit it");
            Destroy(Rocket);
        }
    }
}
