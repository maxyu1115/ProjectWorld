using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;
    void Start()
    {
        pausePanel.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!pausePanel.activeInHierarchy)
            {
                PauseGame();
            }
            if (pausePanel.activeInHierarchy)
            {
                ContinueGame();
            }
        }
    }
    public void PauseGame()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
    }
    public void ContinueGame()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }
    public void Save_Quit()
    {
        SceneManager.LoadScene("Start Menu");
    }
}
