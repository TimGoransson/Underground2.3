using UnityEngine;
using System.Collections;

public class SwordStatusScript : MonoBehaviour
{
    //if (GameObject.FindGameObjectWithTag("CharSelect").GetComponent<MenuManager>().SelectedSword == false || GameObject.FindGameObjectWithTag("CharSelect").GetComponent<MenuManager>().SelectedSword == null)
	// Use this for initialization
    void Start()
    {
        if(MenuManager.SelectedSword == false)
        {
            Destroy(gameObject);
        }
    }
	// Update is called once per frame
	void Update () {
	
	}
}
