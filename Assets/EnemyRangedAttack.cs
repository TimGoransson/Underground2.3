using UnityEngine;
using System.Collections;

public class EnemyRangedAttack : MonoBehaviour {
    float range = 100;
    float timer;
    float cooldown;

    public LayerMask whatToHit;

    GameObject target;
    public GameObject bossBullet;
    private EnemyAI enemyAI;

    // Use this for initialization
    void Awake ()
    {
        cooldown = 1;
        timer = cooldown;
        enemyAI = GetComponentInParent<EnemyAI>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (target != null)
        {
            timer -= Time.deltaTime;
            RaycastHit2D hit = Physics2D.Raycast(transform.position, target.transform.position - transform.position, range, whatToHit);
            //Debug.DrawLine(transform.position, (target.transform.position - transform.position) * 100, Color.yellow);
            if (hit.transform.tag == "Player" && timer <= 0)
            {
                Debug.DrawLine(transform.position, hit.point, Color.red);
                GameObject newBullet = Object.Instantiate(bossBullet, transform.position, transform.rotation) as GameObject;
                Rigidbody2D rb = newBullet.GetComponent<Rigidbody2D>();
                Vector2 fireDirection = target.transform.position-transform.position;
                fireDirection.Normalize();
                rb.velocity = fireDirection;
                timer = cooldown;
            }
            else
            {
                Debug.DrawLine(transform.position, (target.transform.position - transform.position), Color.yellow);
            }
        }
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            target = GameObject.FindGameObjectWithTag("Player");
            enemyAI.enabled = false;
            //RaycastHit2D hit = Physics2D.Raycast(transform.position, target.transform.position - transform.position, range, whatToHit);
            //Debug.DrawLine(transform.position, (target.transform.position - transform.position) * 100, Color.yellow);
        }        
    }
    void OnTriggerExit2D(Collider2D other)
    {
        target = null;
        enemyAI.enabled = true;
    }
}
