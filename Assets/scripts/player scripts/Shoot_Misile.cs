using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot_Misile : MonoBehaviour
{
    public GameObject RocketPrefab;
    private float RocketCooldown = 10;
    public Transform RocketMuzzle;
    private float RocketSpeed = 10f;
    public float cd; 

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
}
