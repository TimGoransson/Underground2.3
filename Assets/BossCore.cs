using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BossCore : MonoBehaviour {
    float currentHealth = 200;
    float maxHealth = 250;

    public EnemyLootDrop lootSpawner;
    float damage = 10;
    

    //void OnTriggerEnter2D(Collider2D other)
    //{
    //    other.SendMessageUpwards("Damage", damage);
    //    Debug.Log("Hit");
    //    //Destroy(gameObject);
    //    //Destroy(other.gameObject);
    //}
    public void Awake()
    {
        currentHealth = maxHealth;        
        //inventoryItemList = (ItemDataBaseList)Resources.Load("ItemDatabase");
    }
    public void Update()
    {
        if (currentHealth <= 0)
        {
            Destroy(transform.parent.gameObject);
            //lootSpawner.DropLoot(new Vector2(this.transform.position.x, this.transform.position.y), 1);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            
        }
    }
    public void Damage(int damage)
    {
        currentHealth -= damage;
    }

    
}
