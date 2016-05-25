using UnityEngine;
using System.Collections;

public class ResetPlayerPos : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameObject.FindGameObjectWithTag("Player").transform.position = this.transform.position;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
