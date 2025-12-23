using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSummon : MonoBehaviour
{
public GameObject towerPrefab;
    public Transform summonPoint;

    void Update()
    {
        // Input summon tower
        if (Input.GetKeyDown(KeyCode.T))
        {
            SummonTower();
        }

        // 👉 kalau mau tambah logic lain,
        // taruh DI SINI, jangan bikin Update baru
    }

    void SummonTower()
    {
        if (towerPrefab == null || summonPoint == null)
        {
            Debug.LogWarning("Tower prefab atau summon point belum di-set!");
            return;
        }

        Instantiate(towerPrefab, summonPoint.position, Quaternion.identity);
    }
}
