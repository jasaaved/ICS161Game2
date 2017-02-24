using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour {

    public GameObject start;
    public GameObject controls;

    public void Control()
    {
        controls.SetActive(true);
        start.SetActive(false);
    }

    public void startmenu()
    {
        start.SetActive(true);
        controls.SetActive(false);
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("DemoScene");
    }

    public void LoadSurvival()
    {
        SceneManager.LoadScene("Survival");
    }
}
