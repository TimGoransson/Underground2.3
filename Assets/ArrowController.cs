using UnityEngine;
using System.Collections;

public class ArrowController : MonoBehaviour {
    public float damage = 5;
    public float fullDamage;
    public float speed = 100;
    public float fallBoundry = -20;
    public float timer = 2;
    
    public Rigidbody2D rb;
	void Start ()
    {
        speed = 30;
        rb.velocity = new Vector2(speed * rb.velocity.x, speed * rb.velocity.y);
    }
	
	void Update ()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Destroy(gameObject);
            timer = 2;
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        fullDamage = damage + GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>().maxDamage 
            + GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>().Str;
        if (other.collider.tag == "Enemy")
        {
            
            other.collider.SendMessageUpwards("Damage", fullDamage);
            Destroy(gameObject);
            Debug.Log("damage = " + fullDamage);
        }
        else if (other.collider.tag != "Enemy")
        {
            Destroy(gameObject);
        }
        //Destroy(other.gameObject);
    }
}
