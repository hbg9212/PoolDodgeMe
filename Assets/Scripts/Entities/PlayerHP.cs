using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    [SerializeField]
    private Slider hpbar;
    private float maxHp = 100;

    public int maxHealth = 100; // 최대 체력
    public int currentHealth; // 현재 체력

    void Start()
    {
        currentHealth = maxHealth; // 시작 시 최대 체력으로 초기화
        hpbar.value = (float)currentHealth / (float)maxHealth;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Trap") || collision.CompareTag("Poop"))
        {
            DecreaseHealth(5); // 충돌 시 체력을 5 감소시킴
        }
        else if (collision.CompareTag("Heart"))
        {
            ItemHeart heart = collision.GetComponent<ItemHeart>();
            if (heart != null)
            {
                IncreaseHealth(10); // Heart 아이템을 먹으면 체력 10 증가
                heart.gameObject.SetActive(false); // Heart 아이템 비활성화
            }
        }
    }

    public void DecreaseHealth(int amount)
    {
        currentHealth -= amount; // 체력을 감소시킴
        HandleHp(); // 체력 업데이트
    }

    private void HandleHp()
    {
        // 체력이 0보다 작거나 같으면 0으로 설정
        currentHealth = Mathf.Max(currentHealth, 0);
        hpbar.value = (float)currentHealth / (float)maxHealth;
    }

    public void IncreaseHealth(int amount)
    {
        int totalHealth = currentHealth + amount;
        if (totalHealth > maxHealth)
        {
            currentHealth = maxHealth;        // 총 체력이 최대 체력을 넘지 않도록 조정
        }
        else
        {
            currentHealth = totalHealth;
        }

        HandleHp(); // 체력 업데이트
    }
}
