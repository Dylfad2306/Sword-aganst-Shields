using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShopPoisen : MonoBehaviour
{
    public  playerstatsscipt playerstatsscipt;
    float basicPotionBoost = 2;

    float healthPotionDuration;
    float damagePotionDuration;

    bool HealthPoisenIsActive = false;
    bool damagePotionIsActive = false;

    public void HealthPotion ()
    {
        if (playerstatsscipt.gold >= 10)
        { 
            playerstatsscipt.gold -= 10;
            playerstatsscipt.PlayerHP *= basicPotionBoost;
            healthPotionDuration = Time.time + 60;
            HealthPoisenIsActive = true;
        }
    }

    public void DamagePotion ()
    {
        if (playerstatsscipt.gold >= 10)
        {
            playerstatsscipt.gold -= 10;
            playerstatsscipt.playerDamage *= basicPotionBoost;
            damagePotionDuration = Time.time + 60;
            damagePotionIsActive = true;
        }
    }
    void Update ()
    {
        if (healthPotionDuration <= Time.time && HealthPoisenIsActive == true)
        {
            playerstatsscipt.PlayerHP /= 2;
            HealthPoisenIsActive = false;
        }

        if (damagePotionDuration <= Time.time &&  damagePotionIsActive == true)
        {
            playerstatsscipt.playerDamage /= 2;
            damagePotionIsActive = false;
        }
    }
}
