using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth;
    [HideInInspector] public int currentHealth;

    public HealthBar healthBar;

    public UnityEvent OnDeath;

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
        Destroy(gameObject);
    }

    private void UpdateBar(Collision2D collision)
    {

        // if (collision.gameObject.CompareTag("Enemy"))
        //{
        //    TakeDam(10); // Trừ 10 máu khi va chạm với kẻ địch
        //}
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDam(10); // Trừ 10 máu khi nhấn phím Space
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        UpdateBar(collision);
    }
}
