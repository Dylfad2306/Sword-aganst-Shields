using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class GunShooting : MonoBehaviour
{
    public Transform muzzleOne; // Point where bullets will be spawned
    public Transform muzzleTwo; // Point where bullets will be spawned
    public GameObject bulletPrefab; // Prefab of the bullet/projectile
    public GameObject CasingPrefab; // Prefab of the casing
    public CardSelectionManager CardSelectionManager;
    public float bulletSpeed = 10f; // Speed of the bullet
    public float CasingSpeed = 1.0f;
    public float bulletDrop = 0.5f; // Adjust the bullet drop factor
    public float fireRate = 600f; // Rounds per minute

    private float timeBetweenShots;
    private float nextShotTime = 0f;

    void Update()
    {
        if ((Input.GetKey(KeyCode.Space)) && Time.time >= nextShotTime)
        {
            ShootOne();
            ShootOneAbilityBonus();
            ShootTwo();
            ShootTwoAbilityBonus();
            nextShotTime = Time.time + 1f / (fireRate / 60f); // Calculate next shot time based on RPM
        }
    }

    void ShootOne()
    {
        // Instantiate a new bullet at the muzzle position
        GameObject bullet = Instantiate(bulletPrefab, muzzleOne.position, muzzleOne.rotation);
        DropCasingLeft();

        // Access the Rigidbody (assuming the bulletPrefab has one)
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();

        if (bulletRb != null)
        {
            // Set the velocity of the bullet in the forward direction of the muzzle with bullet drop
            Vector2 bulletVelocity = muzzleOne.up * bulletSpeed;
            bulletVelocity += Physics2D.gravity * bulletDrop;
            bulletRb.velocity = bulletVelocity;

            // If you're using a sprite with a different orientation, you might need to use muzzle.right or muzzle.forward
        }
        else
        {
            Debug.LogError("Bullet prefab must have a Rigidbody2D component.");
        }

        // Destroy the bullet after a certain time (e.g., 2 seconds)
        Destroy(bullet, 2f);
    }
    void ShootOneAbilityBonus()
    {
        if (CardSelectionManager.dubleBulletsActive == true)
        {
            // Instantiate a new bullet at the muzzle position
            GameObject bullet = Instantiate(bulletPrefab, muzzleOne.position, muzzleOne.rotation);
            DropCasingLeft();

            // Access the Rigidbody (assuming the bulletPrefab has one)
            Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();

            if (bulletRb != null)
            {
             // Set the velocity of the bullet in the forward direction of the muzzle with bullet drop
                Vector2 bulletVelocity = muzzleOne.up * bulletSpeed;
                bulletVelocity += Physics2D.gravity * bulletDrop;
                bulletRb.velocity = bulletVelocity;

                // If you're using a sprite with a different orientation, you might need to use muzzle.right or muzzle.forward
            }
            else
            {
                Debug.LogError("Bullet prefab must have a Rigidbody2D component.");
            }

            // Destroy the bullet after a certain time (e.g., 2 seconds)
            Destroy(bullet, 2f);
        }
        
    }
    void ShootTwo()
    {
        // Instantiate a new bullet at the muzzle position
        GameObject bullet = Instantiate(bulletPrefab, muzzleTwo.position, muzzleTwo.rotation);
        DropCasingRight();

        // Access the Rigidbody (assuming the bulletPrefab has one)
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();

        if (bulletRb != null)
        {
            // Set the velocity of the bullet in the forward direction of the muzzle with bullet drop
            Vector2 bulletVelocity = muzzleTwo.up * bulletSpeed;
            bulletVelocity += Physics2D.gravity * bulletDrop;
            bulletRb.velocity = bulletVelocity;

            // If you're using a sprite with a different orientation, you might need to use muzzle.right or muzzle.forward
        }
        else
        {
            Debug.LogError("Bullet prefab must have a Rigidbody2D component.");
        }

        // Destroy the bullet after a certain time (e.g., 2 seconds)
        Destroy(bullet, 2f);
    }
    void ShootTwoAbilityBonus()
    {
        if (CardSelectionManager.dubleBulletsActive == true)
        {
            // Instantiate a new bullet at the muzzle position
            GameObject bullet = Instantiate(bulletPrefab, muzzleTwo.position, muzzleTwo.rotation);
            DropCasingRight();

            // Access the Rigidbody (assuming the bulletPrefab has one)
            Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();

            if (bulletRb != null)
            {
                //Set the velocity of the bullet in the forward direction of the muzzle with bullet drop
                Vector2 bulletVelocity = muzzleTwo.up * bulletSpeed;
                bulletVelocity += Physics2D.gravity * bulletDrop;
                bulletRb.velocity = bulletVelocity;

                // If you're using a sprite with a different orientation, you might need to use muzzle.right or muzzle.forward
            }
            else
            {
                Debug.LogError("Bullet prefab must have a Rigidbody2D component.");
            }

            // Destroy the bullet after a certain time (e.g., 2 seconds)
            Destroy(bullet, 2f);
         }
        
    }
    void DropCasingLeft()
    {
        GameObject Casing = Instantiate(CasingPrefab, muzzleOne.position, muzzleOne.rotation);

        Casing.GetComponent<Rigidbody2D>().AddForce(new Vector2(-3f, 0f), ForceMode2D.Impulse);
        Destroy(Casing, 1f);
    }
    void DropCasingRight()
    {
        GameObject Casing = Instantiate(CasingPrefab, muzzleTwo.position, muzzleTwo.rotation);

        Casing.GetComponent<Rigidbody2D>().AddForce(new Vector2(3f, 0f), ForceMode2D.Impulse);
        Destroy(Casing, 1f);
    }
}