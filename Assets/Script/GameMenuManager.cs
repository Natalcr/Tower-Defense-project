using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameMenuManager : MonoBehaviour
{
public GameObject mainMenuPanel;
    public GameObject hudPanel; // Tambahkan slot untuk HUD

    private bool isPaused = false;

    void Start()
    {
        ShowMenu();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused) ResumeGame();
            else ShowMenu();
        }
    }

    public void ShowMenu()
    {
        mainMenuPanel.SetActive(true);
        hudPanel.SetActive(false); // Sembunyikan HUD saat di Menu
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame()
    {
        mainMenuPanel.SetActive(false);
        hudPanel.SetActive(true); // Tampilkan HUD saat bermain
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void RestartToMain()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
