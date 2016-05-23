using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {
    private bool attacking = false;
    private float attackTimer = 0;
    private float attackCooldown = 0.3f;

    public BoxCollider2D meleeCollider;
    private Animator anim;
	// Use this for initialization
	void Awake ()
    {
        // anim = 
        meleeCollider.enabled = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown("f") && !attacking)
        {
            attacking = true;
            attackTimer = attackCooldown;
            meleeCollider.enabled = true;
        }
        if (attacking && attackTimer > 0)
        {
            attackTimer -= Time.deltaTime;
        }
        else
        {
            attacking = false;
            meleeCollider.enabled = false;
        }
	}
}
