using UnityEngine;
using System.Collections;

public class ArrowCharStatus : MonoBehaviour
{
     //if(GameObject.FindGameObjectWithTag("CharSelect").GetComponent<MenuManager>().SelectedBow == false)
	// Use this for initialization
    bool spawnBow = true;
    void Start()
    {
        if(MenuManager.SelectedBow == false)
        {
            Destroy(gameObject);
        }
    }
	void Awake () 
    {

	
	}
	// Update is called once per frame
	void Update () {
	
	}
}
