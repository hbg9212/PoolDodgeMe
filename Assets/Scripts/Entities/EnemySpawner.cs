using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // 생성할 Enemy 프리팹
    public float spawnInterval = 5.0f; // Enemy 생성 간격 (초)

    private Vector3[] spawnPositions; // Enemy가 생성될 위치 좌표 배열
    private int currentSpawnPositionIndex = 0; // 현재 생성 위치 인덱스
    private float timer = 0.0f; // 생성 타이머

    // 생성될 위치 좌표를 Awake()에서 초기화
    private void Awake()
    {
        // 원하는 위치 좌표를 직접 설정
        spawnPositions = new Vector3[]
        {
            new Vector3(13f, 0f, 0f), // 오른쪽
            new Vector3(-13f, 0f, 0f), // 왼쪽
            new Vector3(0f, 7f, 0f), // 위
            new Vector3(0f, -7f, 0f) // 아래
        };
    }

    private void Update()
    {
        // 일정 시간 간격으로 Enemy 생성
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnEnemy();
            timer = 0.0f; // 타이머 초기화
        }
    }

    private void SpawnEnemy()
    {
        // 현재 인덱스에 해당하는 위치에 Enemy 생성
        Vector3 spawnPosition = spawnPositions[currentSpawnPositionIndex];
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

        // 다음 인덱스로 이동 (순환)
        currentSpawnPositionIndex = (currentSpawnPositionIndex + 1) % spawnPositions.Length;
    }
}
