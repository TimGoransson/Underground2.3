using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour
{

    public float fireRate = 60;
    public float dmg;
    public float range = 100;
    public LayerMask whatToHit;
    float counter = 60;
    float timeToFire = 0;
    Transform firePoint;

    public GameObject arrow;
    public Rigidbody2D arrowBody;

    // Use this for initialization
    void Awake()
    {
        firePoint = transform.FindChild("FirePoint");
        if (firePoint == null)
        {
            Debug.LogError("missing firepoint");
        }
    }

    // Update is called once per frame
    void Update()
    {
        counter++;
        fireRate++;
        // dmg = PlayerInventory.
        if (fireRate >= (30 - GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>().Dex))
        {
            if (Input.GetButtonDown("Fire1"))
            {
                if (counter >= fireRate)
                {
                    fireRate = 0;
                    counter = 0;
                    Shoot();

                }
            }
        }
        //else if(Input.GetButton("Fire1") && Time.time > timeToFire)
        //{
        //    timeToFire = Time.time + 1 / fireRate;

        //    Shoot();
        //}
    }
    void Shoot()
    {

        Vector2 mousePosition = new Vector2
            (Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
            Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        Vector2 firePointPosition = new Vector2(firePoint.position.x, firePoint.position.y);
        Vector2 fireDirection = (mousePosition - firePointPosition);
        fireDirection.Normalize();
        RaycastHit2D hit = Physics2D.Raycast(firePointPosition, mousePosition - firePointPosition, range, whatToHit);
        Debug.DrawLine(firePointPosition, (mousePosition - firePointPosition) * 100, Color.yellow);
        if (hit.collider != null)
        {
            Debug.DrawLine(firePointPosition, hit.point, Color.red);
        }

        GameObject newArrow = Object.Instantiate(arrow, firePointPosition, firePoint.rotation) as GameObject;
        Rigidbody2D rb = newArrow.GetComponent<Rigidbody2D>();
        rb.velocity = fireDirection;
        newArrow.transform.rotation = Quaternion.Euler(0f, 0f, Mathf.Rad2Deg * Mathf.Atan2(fireDirection.y, fireDirection.x));

    }
}
