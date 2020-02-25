using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    public GameObject EndMenuUI;


    public void GameOver()
    {
        StartCoroutine(stop());
    }
    public void Restart()
    {
        EndMenuUI.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }
    IEnumerator stop() {
        yield return new WaitForSeconds(2f);
        EndMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Quit()
    {
        Application.Quit();
    }
}
