using System.Collections;
using TMPro;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
public GameObject enemyPrefab;
    public Transform spawnPoint;

    [Header("Wave Settings")]
    public int totalWaves = 5;
    public int baseEnemyCount = 3;
    public float spawnDelay = 1f;
    public float timeBetweenWaves = 3f;

    [Header("UI Reference")]
    public TextMeshProUGUI waveText;
    public TextMeshProUGUI enemyText;

    [HideInInspector] public int currentWave = 0;
    [HideInInspector] public int enemiesAlive = 0;
    private bool spawning = false;
    private Base baseScript; 

    void Start()
    {
        baseScript = FindObjectOfType<Base>(); 
        currentWave = 0;
        enemiesAlive = 0;
        StartNextWave();
    }

    void Update()
    {
        if (waveText != null) waveText.text = "Wave: " + currentWave + "/" + totalWaves;
        if (enemyText != null) enemyText.text = "Enemies: " + enemiesAlive;
    }

    void StartNextWave()
    {
        if (currentWave >= totalWaves) return;
        currentWave++;
        int enemyCount = baseEnemyCount + (currentWave - 1) * 2;
        StartCoroutine(SpawnWave(enemyCount));
    }

    IEnumerator SpawnWave(int count)
    {
        spawning = true;
        for (int i = 0; i < count; i++)
        {
            GameObject enemyGO = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
            Enemy enemy = enemyGO.GetComponent<Enemy>();
            if (enemy != null) enemy.Init(this); 

            enemiesAlive++;
            yield return new WaitForSeconds(spawnDelay);
        }
        spawning = false;
        CheckWaveComplete();
    }

    public void OnEnemyRemoved()
    {
        enemiesAlive--;
        if (enemiesAlive < 0) enemiesAlive = 0; 
        CheckWaveComplete();
    }

    void CheckWaveComplete()
    {
        if (enemiesAlive <= 0 && !spawning)
        {
            if (currentWave >= totalWaves)
            {
                // Panggil WinGame jika semua musuh di wave terakhir sudah mati
                if (baseScript != null) baseScript.WinGame();
            }
            else
            {
                Invoke("StartNextWave", timeBetweenWaves);
            }
        }
    }
}
