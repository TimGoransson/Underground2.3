using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    [System.Serializable]
    public class PlayerStats
    {
        public float Health = 100;

    }
    public PlayerStats playerStats = new PlayerStats();

    public int fallBoundary = -20;
    void Update()
    {
        if(transform.position.y <= fallBoundary)
        {
            Destroy(gameObject);
        }
    }
    
    
    //public void Damage(float damage)
    //{
    //    playerStats.Health -= damage;
    //    if (playerStats.Health <= 0)
    //    {
    //        Debug.Log("KILL PLAYER");
    //        GameMaster.KillPlayer(this);
    //    }
    //}
   
}
