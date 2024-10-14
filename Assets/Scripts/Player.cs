using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Vector3 moveInput;
    public SpriteRenderer characterSR;
    public GameObject damPopUp;

    private void Update()
    {
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");
        transform.position += moveInput * moveSpeed * Time.deltaTime;

        //animator.SetFloat("speed", moveInput.sqrMagnitude);

        if (moveInput.x != 0)
        {
            if (moveInput.x > 0)
                characterSR.transform.localScale = new Vector3(1, 1, 0);
            else
                characterSR.transform.localScale = new Vector3(-1, 1, 0);
        }
    }

    public void TakeDamageEffect(int damage)
    {
        if (damPopUp != null)
        {
            GameObject instance = Instantiate(damPopUp, transform.position
                    + new Vector3(UnityEngine.Random.Range(-0.3f, 0.3f), 0.5f, 0), Quaternion.identity);
            instance.GetComponentInChildren<TextMeshProUGUI>().text = damage.ToString();
            Animator animator = instance.GetComponentInChildren<Animator>();
            animator.Play("red");
        }
        //if (GetComponent<HealthBar>().isDead)
        //{
        //    losePanel.Show();
        //}
    }

}
