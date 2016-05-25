using UnityEngine;
using System.Collections;

public class swordStrike : MonoBehaviour
{
    public float damage = 15;
    public float fullDamage;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter2D(Collision2D other)
    {
        fullDamage = damage + GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>().maxDamage;
        if (other.collider.tag == "Enemy")
        {
            other.collider.SendMessageUpwards("Damage", fullDamage);
            Debug.Log("damage = " + fullDamage);
            
            
        }

    }
}
