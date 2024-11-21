using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject enemyPrefab; // Prefab c?a k? ??ch
    private int spawnCount = 1;    // S? l??ng k? ??ch xu?t hi?n ban ??u
    private int currentEnemyCount = 0; // S? l??ng k? ??ch hi?n t?i

    void Update()
    {
        if (currentEnemyCount == 0)
            SpawnEnemies();
    }



    // Hàm g?i khi k? ??ch ch?t ?? t?o thêm k? ??ch
    public void SpawnEnemies()
    {

        currentEnemyCount += 2;

        Vector3 randomPosition = new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f), 0); // V? trí ng?u nhiên
        GameObject enemy = Instantiate(enemyPrefab, randomPosition, Quaternion.identity);

        // G?i Respawn() ?? khôi ph?c tr?ng thái di chuy?n c?a k? ??ch
        enemy.GetComponent<EnemyAI>().Respawn();

    }
}
