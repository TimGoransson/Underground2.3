using UnityEngine;
using System.Collections;

public class PauseGame : MonoBehaviour
{

    // Use this for initialization
    bool paused = false;
    public Transform pauseChild;
    void Start()
    {

    }
    public void Pause()
    {
        paused = true;
        Time.timeScale = 0f;

        if (paused == true)
        {
            //pauseChild = transform.Find("resumeButton");
            transform.GetChild(0).GetChild(1).gameObject.SetActive(true);
        }

    }
    public void Resume()
    {
        Time.timeScale = 1f;

        transform.GetChild(0).GetChild(1).gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {

    }
}
