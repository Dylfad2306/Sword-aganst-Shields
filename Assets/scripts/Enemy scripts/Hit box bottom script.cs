using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitboxbottomscript : MonoBehaviour
{
    public playerstatsscipt playerScript;
    // Update is called once per frame
    private void Start()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the object the script collided with has the "Enemy" tag
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Run the code you want here
            Debug.Log("Enemy hit!");
            playerScript.PlayerHP -= 1;
            Destroy(collision.gameObject);
        }
    }
}
