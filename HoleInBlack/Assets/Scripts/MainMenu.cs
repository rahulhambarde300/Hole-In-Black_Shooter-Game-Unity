using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject AboutUI;
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void ExitGame()
    {
        Application.Quit ();
    }
    public void About()
    {
        AboutUI.SetActive(true);
        gameObject.SetActive(false);
    }
    public void MainMenuUi()
    {
        AboutUI.SetActive(false);
        gameObject.SetActive(true);
    }
}
