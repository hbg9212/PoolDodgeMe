using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    [SerializeField]
    private Slider hpbar;
    private float maxHp = 100;

    public int maxHealth = 100; // �ִ� ü��
    public int currentHealth; // ���� ü��

    void Start()
    {
        currentHealth = maxHealth; // ���� �� �ִ� ü������ �ʱ�ȭ
        hpbar.value = (float)currentHealth / (float)maxHealth;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Trap") || collision.CompareTag("Poop"))
        {
            DecreaseHealth(5); // �浹 �� ü���� 5 ���ҽ�Ŵ
        }
        else if (collision.CompareTag("Heart"))
        {
            ItemHeart heart = collision.GetComponent<ItemHeart>();
            if (heart != null)
            {
                IncreaseHealth(10); // Heart �������� ������ ü�� 10 ����
                heart.gameObject.SetActive(false); // Heart ������ ��Ȱ��ȭ
            }
        }
    }

    public void DecreaseHealth(int amount)
    {
        currentHealth -= amount; // ü���� ���ҽ�Ŵ
        HandleHp(); // ü�� ������Ʈ
    }

    private void HandleHp()
    {
        // ü���� 0���� �۰ų� ������ 0���� ����
        currentHealth = Mathf.Max(currentHealth, 0);
        hpbar.value = (float)currentHealth / (float)maxHealth;
    }

    public void IncreaseHealth(int amount)
    {
        int totalHealth = currentHealth + amount;
        if (totalHealth > maxHealth)
        {
            currentHealth = maxHealth;        // �� ü���� �ִ� ü���� ���� �ʵ��� ����
        }
        else
        {
            currentHealth = totalHealth;
        }

        HandleHp(); // ü�� ������Ʈ
    }
}
