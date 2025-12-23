using UnityEngine;
using TMPro;

public class Base : MonoBehaviour
{
public int maxHealth = 5;
    public int currentHealth;

    [Header("UI Reference")]
    public TextMeshProUGUI hpText;
    public GameObject gameOverPanel;
    public TextMeshProUGUI statusText;

    void Start()
    {
        currentHealth = maxHealth;
        if (gameOverPanel != null) gameOverPanel.SetActive(false);
        UpdateHPUI();
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        UpdateHPUI();

        if (currentHealth <= 0)
        {
            LoseGame();
        }
    }

    void UpdateHPUI()
    {
        if (hpText != null) hpText.text = "Base HP: " + currentHealth;
    }

    public void LoseGame()
    {
        Time.timeScale = 0f; // Menghentikan permainan
        if (gameOverPanel != null) gameOverPanel.SetActive(true);
        if (statusText != null)
        {
            statusText.text = "GAME OVER";
            statusText.color = Color.red;
        }
    }

    public void WinGame()
    {
        Time.timeScale = 0f; // Menghentikan permainan
        if (gameOverPanel != null) gameOverPanel.SetActive(true);
        if (statusText != null)
        {
            statusText.text = "YOU WIN!";
            statusText.color = Color.green;
        }
    }
}
