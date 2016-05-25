using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{

    // Use this for initialization
    public static bool SelectedSword;
    public static bool SelectedBow;
    public static bool SelectedMagic;
    public static float Dex;
    public static float Str;
    public static float health;
    public static float mana;
    Text healthValue;
    Text manaValue;
    Text dexValue;
    Text strValue;



    public void StartGame()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
    public void QuitGame()
    {
        Debug.Log("The game Quit");
        Application.Quit();
    }
    public void Cancel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    public void Play()
    {
        if (SelectedBow)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        if (SelectedSword)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene(1);
    }
    public void SelectSword()
    {
        //activeChar = SwordGuy;
        SelectedSword = true;
        SelectedMagic = false;
        SelectedBow = false;
    }
    public void SelectBow()
    {
        //activeChar = BowGuy;
        SelectedBow = true;
        SelectedSword = false;
        SelectedMagic = false;
    }
    public void SelectMagic()
    {
        //activeChar = MagicGuy;
        SelectedMagic = true;
        SelectedBow = false;
        SelectedSword = false;
    }

    public void Dexterity(GameObject CanvasCharScreen)
    {
        Dex = Random.Range(2, 6);
        dexValue = CanvasCharScreen.transform.GetChild(4).GetChild(0).GetComponent<Text>();
        dexValue.text = (" " + Dex);
    }

    public void Strenght(GameObject CanvasCharScreen)
    {
        Str = Random.Range(2, 6);
        strValue = CanvasCharScreen.transform.GetChild(3).GetChild(0).GetComponent<Text>();
        strValue.text = ("" + Str);
    }

    public void Health(GameObject CanvasCharScreen)
    {
        health = Random.Range(30, 50);
        healthValue = CanvasCharScreen.transform.GetChild(2).GetChild(0).GetComponent<Text>();
        healthValue.text = ("" + health);
    }
    //public void Mana(GameObject CanvasCharScreen)
    //{
    //    mana = Random.Range(30, 50);
    //    manaValue = CanvasCharScreen.transform.GetChild(3).GetChild(0).GetComponent<Text>();
    //    manaValue.text = ("" + mana);
    //}

    // Update is called once per frame
    void Update()
    {

    }
}
