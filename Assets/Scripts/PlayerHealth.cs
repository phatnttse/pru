using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    [HideInInspector] public int currentHealth;

    public HealthBar healthBar;
    public UnityEvent OnDeath;

    // Biến để kiểm soát khoảng thời gian giữa các lần trừ máu
    public float damageInterval = 1f; // Mỗi giây trừ 10 máu
    private float lastDamageTime = 0f;

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
    }

    public void TakeDam(int damage)
    {
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
        Destroy(gameObject); // Khi chết sẽ phá hủy đối tượng
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
}