using UnityEngine;
using System.Collections;

public class BossSegment : MonoBehaviour {

    [System.Serializable]
    public class EnemyStats
    {
        public float maxHealth = 100;

        private float _curhealth = 10;


        public float currentHealth
        {
            get { return _curhealth; }
            set { _curhealth = Mathf.Clamp(value, 0, maxHealth); }

        }

        public void Init()
        {
            currentHealth = maxHealth;
            Debug.Log(currentHealth);
        }

    }

    public EnemyLootDrop lootSpawner;

    float damage = 5;
    float hitCd;
    float hitTimer;

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Player" && hitTimer <= 0)
        {
            hitTimer = hitCd;
            other.collider.SendMessageUpwards("Damage", damage);

        }
        Debug.Log("Hit");

    }
    public EnemyStats stats = new EnemyStats();

    [Header("Optional: ")]
    [SerializeField]
    private StatusIndicator statusIndicator;

    BossAI bossAI;

    void Start()
    {
        hitCd = 1.5f;
        hitTimer = hitCd;
        bossAI = transform.parent.GetComponent<BossAI>();

        stats.Init();

        if (statusIndicator != null)
        {
            statusIndicator.SetHealth(stats.currentHealth, stats.maxHealth);
        }
    }
    public void Update()
    {
        hitTimer -= Time.deltaTime;
        if (stats.currentHealth <= 0)
        {
            bossAI.rotationSpeed *= 2;
            GetComponent<CircleCollider2D>().enabled = true;
                        
            lootSpawner.DropLoot(new Vector2(this.transform.position.x, this.transform.position.y), 1);
        }
        if (statusIndicator != null)
        {
            statusIndicator.SetHealth(stats.currentHealth, stats.maxHealth);
        }
    }
    public void Damage(int damage)
    {
        stats.currentHealth -= damage;
        //if()
    }
    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            other.SendMessageUpwards("ActivateGun");
            Destroy(gameObject);
        }
    }
}
