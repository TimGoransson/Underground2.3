using UnityEngine;
using System.Collections;

public class DestroyCameraBow : MonoBehaviour {

	// Use this for initialization
	void Start () {
        if (MenuManager.SelectedSword == true)
        {
            Destroy(gameObject);
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
