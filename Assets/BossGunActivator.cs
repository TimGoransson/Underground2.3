using UnityEngine;
using System.Collections;

public class BossGunActivator : MonoBehaviour {

	// Use this for initialization
	void Awake () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void ActivateGun()
    {
        GetComponent<BossWeapon>().enabled = true;
        GetComponent<BoxCollider2D>().enabled = false;
    }
}
