using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int minDamage = 6;
    public int maxDamage = 16;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            int damage = Random.Range(minDamage, maxDamage);
            Destroy(gameObject);
            // L?y script Enemy và g?i hàm TakeDamage ?? tr? máu
            EnemyAI enemy = collision.gameObject.GetComponent<EnemyAI>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage); // Gây sát th??ng
            }
        }

    }
}
