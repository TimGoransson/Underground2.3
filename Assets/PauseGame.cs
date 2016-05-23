using UnityEngine;
using System.Collections;

public class PauseGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
    public void Pause()
    {
       
           Time.timeScale = 0f;
       
    }
    public void Resume()
    {
        Time.timeScale = 1f;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
