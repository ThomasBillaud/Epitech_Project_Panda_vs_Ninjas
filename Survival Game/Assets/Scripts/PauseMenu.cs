using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject Pause;
    public GameObject Controls;

    public void PauseGame()
    {
        Time.timeScale = 0f;
        Pause.SetActive(true);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        Pause.SetActive(false);
    }

    public void QuitGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape) && Controls.activeInHierarchy == false) {
            if (Pause.activeInHierarchy == false)
                PauseGame();
            else
                RestartGame();
        }
    }
}
