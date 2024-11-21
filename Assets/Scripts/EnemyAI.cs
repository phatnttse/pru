using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    // Shoot
    public int maxHealth = 50;
    public int health;
    public int scoreValue = 1;
    // Hồi sinh 
    public EnemyManager enemyManager;

    // Thay đổi trạng thái để kiểm soát hành vi
    private bool isMoving = true; // Kẻ địch có di chuyển hay không

    public PlayerHealth player;

    void Start()
    {
        if (player == null) // Nếu chưa kéo thả Player vào từ Inspector
        {
            player = GameObject.FindWithTag("Player").GetComponent<PlayerHealth>();

            if (player == null)
            {
                Debug.LogError("PlayerHealth component not found on any GameObject with tag 'Player'!");
            }
        }
        health = maxHealth;
        if (enemyManager == null)
        {
            enemyManager = FindObjectOfType<EnemyManager>();
        }
    }

    void Update()
    {

        // Nếu kẻ địch đang di chuyển, thực hiện logic di chuyển và bắn
        if (isMoving)
        {
            MoveTowardsPlayer();
        }

    }

    void MoveTowardsPlayer()
    {
        Player player = FindObjectOfType<Player>();
        if (player != null)
        {
            Vector3 direction = (player.transform.position - transform.position).normalized;
            transform.position += direction * Time.deltaTime; // Di chuyển về phía người chơi
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage; // Trừ máu khi nhận sát thương
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Gọi EnemyManager để tạo thêm kẻ địch khi kẻ địch chết
        if (enemyManager != null)
        {
            enemyManager.SpawnEnemies();
        }

        // Ngừng di chuyển và chỉ đứng yên trong một khoảng thời gian
        isMoving = false;
        Debug.Log("Enemy died. Adding score: " + scoreValue);
        // Xóa kẻ địch
        Destroy(gameObject);
        //player.AddScore(scoreValue);
    }

    // Hàm được gọi khi kẻ địch hồi sinh
    public void Respawn()
    {
        health = maxHealth;
        isMoving = true; // Khôi phục khả năng di chuyển
    }
}
