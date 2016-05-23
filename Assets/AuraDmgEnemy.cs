using UnityEngine;
using System.Collections;

public class AuraDmgEnemy : MonoBehaviour {
    float damage;
	// Use this for initialization
	void Awake () 
    {
        damage = 5;
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.SendMessageUpwards("Damage", damage);

        }
        Debug.Log("Hit");

    }
}
