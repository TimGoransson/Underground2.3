using UnityEngine;
using System.Collections;

public class BossSegmentActivator : MonoBehaviour {

	// Use this for initialization
	void Awake () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnDestroy()
    {
        if (this.name == "NW_Shell")
        {
            BossWeapon bW = transform.parent.FindChild("Core").FindChild("NW").GetComponentInChildren<BossWeapon>();
            bW.enabled = true;
            bW.speedMultiplyer *= 2;
        }
        if (this.name == "NE_Shell")
        {
            BossWeapon bW = transform.parent.FindChild("Core").FindChild("NE").GetComponentInChildren<BossWeapon>();
            bW.enabled = true;
            bW.speedMultiplyer *= 2;
        }
        if (this.name == "SW_Shell")
        {
            BossWeapon bW = transform.parent.FindChild("Core").FindChild("SW").GetComponentInChildren<BossWeapon>();
            bW.enabled = true;
            bW.speedMultiplyer *= 2;
        }
        if (this.name == "SE_Shell")
        {
            BossWeapon bW = transform.parent.FindChild("Core").FindChild("SE").GetComponentInChildren<BossWeapon>();
            bW.enabled = true;
            bW.speedMultiplyer *= 2;
        }
    }
}
