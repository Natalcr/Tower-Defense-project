using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HUDManager : MonoBehaviour
{
[Header("UI Text References")]
    public TextMeshProUGUI hpText;
    public TextMeshProUGUI waveText;
    public TextMeshProUGUI enemyText;

    [Header("Script References")]
    public Base baseScript;
    public WaveSpawner spawnerScript;

    void Update()
    {
        // Menampilkan HP Base
        if (baseScript != null && hpText != null)
        {
            hpText.text = "Base HP: " + baseScript.currentHealth;
        }

        // Menampilkan Wave dan Musuh langsung dari variabel Public
        if (spawnerScript != null)
        {
            if (waveText != null) 
                waveText.text = "Wave: " + spawnerScript.currentWave + " / " + spawnerScript.totalWaves;
            
            if (enemyText != null) 
                enemyText.text = "Enemies: " + spawnerScript.enemiesAlive;
        }
    }
}

