using UnityEngine;

public class Enemy : MonoBehaviour
{
public int health = 50;

    WaveSpawner waveSpawner;
    bool counted = false;

    // Dipanggil otomatis oleh WaveSpawner saat spawn
    public void Init(WaveSpawner spawner)
    {
        waveSpawner = spawner;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Pastikan Base kamu memiliki Tag "Base" di Inspector
        if (other.CompareTag("Base"))
        {
            Base baseObj = other.GetComponent<Base>();
            if (baseObj != null)
            {
                baseObj.TakeDamage(1);
            }

            Die();
        }
    }

    // Fungsi khusus untuk menghancurkan diri dan melapor
    void Die()
    {
        Destroy(gameObject);
    }

    void OnDestroy()
    {
        // Pengaman: Jika waveSpawner kosong, cari otomatis di scene
        if (waveSpawner == null)
        {
            waveSpawner = FindObjectOfType<WaveSpawner>();
        }

        // Melapor ke spawner agar angka Enemies di UI berkurang
        if (waveSpawner != null && !counted)
        {
            counted = true;
            waveSpawner.OnEnemyRemoved();
        }
    }
}
