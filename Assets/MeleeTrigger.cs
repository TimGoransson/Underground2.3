using UnityEngine;
using System.Collections;

public class MeleeTrigger : MonoBehaviour {
    public int damage = 10;
	void OnTriggerEnter2D(Collider2D col)
    {
        if (col.isTrigger != true && col.CompareTag("Enemy"))
        {
            col.SendMessageUpwards("Damage", damage);
        }
    }
}
