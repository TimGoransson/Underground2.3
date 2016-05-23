using UnityEngine;
using System.Collections;

public class BossWeapon : MonoBehaviour {
    float timer;
    public float cooldown;
    public GameObject bossBullet;
    Transform firePoint;
	void Awake () 
    {
        timer = cooldown;
        firePoint = transform.FindChild("FirePoint");
        if (firePoint == null)
        {
            Debug.LogError("missing firepoint");
        }
        timer = 0.5f;
	}
	
	// Update is called once per frame
	void Update () 
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            Shoot();
            timer = cooldown;
        }

	}
    void Shoot()
    {
        Vector2 firePointPosition = new Vector2(firePoint.position.x, firePoint.position.y);
        Vector2 fireDirection = new Vector2((firePointPosition.x - transform.parent.position.x), (firePointPosition.y - transform.parent.position.y));
        fireDirection.Normalize();
        GameObject newBullet = Object.Instantiate(bossBullet, firePointPosition, firePoint.rotation) as GameObject;
        Rigidbody2D rb = newBullet.GetComponent<Rigidbody2D>();
        rb.velocity = fireDirection;
        newBullet.transform.rotation = Quaternion.Euler(0f, 0f, Mathf.Rad2Deg * Mathf.Atan2(fireDirection.y, fireDirection.x));
    }
}
