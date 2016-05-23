using UnityEngine;
using System.Collections;

public class arm_to_mouse : MonoBehaviour {

    public int rotationOffset = 90;
	
	// Update is called once per frame
	void Update () {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();

        float rotationZ = Mathf.Atan2 (difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotationZ + rotationOffset);
	
	}
}
