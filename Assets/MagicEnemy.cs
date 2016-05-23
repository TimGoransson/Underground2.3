using UnityEngine;
using System.Collections;

public class MagicEnemy : MonoBehaviour
{
    float currentHealth = 10;
    float maxHealth = 100;
    float damage = 10;
    public Transform target;

    public void MagicDmg()
    {

    }
    public void Shoot()
    {
        //if (self - target < 10)
        //{
        //    if (Player.distance from enemy < 100)
        //    {
        //        //Shoot left
        //    }
        //    if (Player.distance from enemy > 100)
        //    {
        //        //Shoot right
        //    }
        //}
    }
    public void Awake()
    {
        currentHealth = maxHealth;
        GetComponent("Target radius");
    }
    public void Update()
    {
        //shoot trigger child circlecollider
        
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void Damage(int damage)
    {
        currentHealth -= damage;
    }
}
