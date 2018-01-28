using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour {

    public void OnClickStart() {
        SceneManager.LoadScene("Main", LoadSceneMode.Single);
    }

    public void OnClickExit() {
        Application.Quit();
    }

    public void OnClickCredits() {
        SceneManager.LoadScene("Credits", LoadSceneMode.Single);
    }

    public void OnClickMenu() {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }

    public GameObject pausepannel, pausebutton;

    public void OnPause()
    {
        Time.timeScale = 0;
        pausepannel.SetActive(true);
        pausebutton.SetActive(false);
    }

    public void NotOnPause()
    {
        Time.timeScale = 1;
        pausepannel.SetActive(false);
        pausebutton.SetActive(true);
    }
}
