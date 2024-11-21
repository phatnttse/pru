using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    [HideInInspector] public int currentHealth;

    public HealthBar healthBar;
    public UnityEvent OnDeath;

    // Biến để kiểm soát khoảng thời gian giữa các lần trừ máu
    public float damageInterval = 1f; // Mỗi giây trừ 10 máu
    private float lastDamageTime = 0f;

    public GameOver gameOverComponent;

    private int score = 0;
    private bool isDead = false; // Biến cờ để xác định trạng thái chết của player

    private void OnEnable()
    {
        OnDeath.AddListener(Death);
    }

    private void OnDisable()
    {
        OnDeath.RemoveListener(Death);
    }

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.UpdateBar(currentHealth, maxHealth);

        score = 0; // Khởi tạo điểm số
    }

    public void TakeDam(int damage)
    {
        // Nếu player đã chết, không thực hiện trừ máu nữa
        if (isDead) return;

        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            OnDeath.Invoke();
        }
        if (currentHealth != maxHealth)
        {
            healthBar.UpdateBar(currentHealth, maxHealth);
        }
    }

    public void Death()
    {
        Destroy(gameObject);
        // Gọi màn hình Game Over từ GameOverComponent
        gameOverComponent.Setup(score);
    }

    // Phương thức xử lý va chạm liên tục
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Nếu đủ thời gian trôi qua từ lần trừ máu trước
            if (Time.time >= lastDamageTime + damageInterval)
            {
                TakeDam(10); // Trừ 10 máu mỗi lần va chạm liên tục
                lastDamageTime = Time.time; // Cập nhật lại thời gian trừ máu
            }
        }
    }

    //public void AddScore(int points)
    //{
    //    Debug.Log("Current Score: " + score); // In ra khi điểm số được cộng
    //    score += points;
    //}

}