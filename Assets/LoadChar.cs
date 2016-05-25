using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadChar : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        if (MenuManager.SelectedSword == true)
        {

            //GameObject SwordInventory = (GameObject)Instantiate(Resources.Load("Invetory and crafting 1"));
            //GameObject HPMANACanvas = (GameObject)Instantiate(Resources.Load("HPMANACanvas"));
            GameObject Sword = (GameObject)Instantiate(Resources.Load("SwordPlayer"));
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        if (MenuManager.SelectedBow == true)
        {
            //GameObject HPMANACanvas = (GameObject)Instantiate(Resources.Load("HPMANACanvas"));
            //GameObject SwordInventory = (GameObject)Instantiate(Resources.Load("Invetory and crafting 1"));
            GameObject Bow = (GameObject)Instantiate(Resources.Load("BowPlayer"));
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
