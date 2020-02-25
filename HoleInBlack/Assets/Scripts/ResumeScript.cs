using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResumeScript : MonoBehaviour
{
    public GameObject PauseUI;
    public void resume()
    {
        Time.timeScale = 1f;
        PauseUI.SetActive(false);

    }
}
