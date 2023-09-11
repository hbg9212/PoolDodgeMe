using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // ������ Enemy ������
    public float spawnInterval = 5.0f; // Enemy ���� ���� (��)

    private Vector3[] spawnPositions; // Enemy�� ������ ��ġ ��ǥ �迭
    private int currentSpawnPositionIndex = 0; // ���� ���� ��ġ �ε���
    private float timer = 0.0f; // ���� Ÿ�̸�

    // ������ ��ġ ��ǥ�� Awake()���� �ʱ�ȭ
    private void Awake()
    {
        // ���ϴ� ��ġ ��ǥ�� ���� ����
        spawnPositions = new Vector3[]
        {
            new Vector3(13f, 0f, 0f), // ������
            new Vector3(-13f, 0f, 0f), // ����
            new Vector3(0f, 7f, 0f), // ��
            new Vector3(0f, -7f, 0f) // �Ʒ�
        };
    }

    private void Update()
    {
        // ���� �ð� �������� Enemy ����
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnEnemy();
            timer = 0.0f; // Ÿ�̸� �ʱ�ȭ
        }
    }

    private void SpawnEnemy()
    {
        // ���� �ε����� �ش��ϴ� ��ġ�� Enemy ����
        Vector3 spawnPosition = spawnPositions[currentSpawnPositionIndex];
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

        // ���� �ε����� �̵� (��ȯ)
        currentSpawnPositionIndex = (currentSpawnPositionIndex + 1) % spawnPositions.Length;
    }
}
