using UnityEngine;
using System.Collections;

public class BossBulletController : MonoBehaviour {

    public int damage = 5;
    public float speed;
    public float Timer = 10;

    public Rigidbody2D rb;
    void Start()
    {
        rb.velocity = new Vector2(speed * rb.velocity.x, speed * rb.velocity.y);
    }

    void Update()
    {
        Timer -= Time.deltaTime;
        if (Timer <= 0)
        {
            Destroy(gameObject);
            Timer = 10;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.SendMessageUpwards("Damage", damage);
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
