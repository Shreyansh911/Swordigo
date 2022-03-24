using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject _pauseUI;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        _pauseUI.SetActive(false);
    }

    public void PauseButton()
    {
        Time.timeScale = 0;
        _pauseUI.SetActive(true);
    }

    public void ResumeButton()
    {
        Time.timeScale = 1;
        _pauseUI.SetActive(false);
    }

    public void RestartButton()
    {
        int ActiveScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(ActiveScene);
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene(0);
    }
}
