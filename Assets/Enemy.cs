using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    
    [System.Serializable]
    public class EnemyStats
    {
        public float maxHealth = 100;
        
        private float _curhealth=10;

        
        public float currentHealth
        {
            get { return _curhealth; }
            set { _curhealth = Mathf.Clamp(value, 0, maxHealth);  }

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

    void Start()
    {
        hitCd = 1.5f;
        hitTimer = hitCd;
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
            Destroy(gameObject);
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
            if(GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>().lifeSteal == true)
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>().currentHealth += GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>().lifeStealValue;
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>().UpdateHPBar();
                Debug.Log("Lifesteal");
            }
    }
}
