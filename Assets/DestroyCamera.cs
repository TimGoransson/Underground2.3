using UnityEngine;
using System.Collections;

public class DestroyCamera : MonoBehaviour {

	// Use this for initialization
	void Start () {
        if (MenuManager.SelectedBow == true)
        {
            Destroy(gameObject);
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
