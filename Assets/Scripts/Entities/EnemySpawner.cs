using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Enemy 프리팹
    public float initialDelay = 1.0f; // 초기 지연 시간 (5초)
    public float spawnInterval = 60.0f; //  생성 간격 (10초로 설정)

    private float spawnYMin = -3f; // Y 좌표 최소값
    private float spawnYMax = 3f; // Y 좌표 최대값

    private void Start()
    {
        // 초기 지연 시간 이후부터 일정 주기마다 아이템을 생성하는 함수 호출
        InvokeRepeating("SpawnEnemies", initialDelay, spawnInterval);
    }

    private void SpawnEnemies()
    {
        // 랜덤하게 결정할 축을 선택합니다 (0은 X 축, 1은 Y 축)
        int randomAxis = Random.Range(0, 2);

        // 생성할 위치의 초기값을 설정합니다.
        float spawnX = 0f;
        float spawnY = 0f;

        // 축을 선택하여 해당 축의 값을 랜덤하게 설정합니다.
        if (randomAxis == 0)
        {
            // X 축을 선택한 경우
            spawnX = Random.Range(-8f, 8f);
            spawnY = (Random.Range(0, 2) == 0) ? -3f : 3f; // -3 또는 3 중에서 랜덤 선택
        }
        else
        {
            // Y 축을 선택한 경우
            spawnX = (Random.Range(0, 2) == 0) ? -8f : 8f; // -8 또는 8 중에서 랜덤 선택
            spawnY = Random.Range(-3f, 3f);
        }

        // 적을 생성할 위치를 설정합니다.
        Vector3 spawnPosition = new Vector3(spawnX, spawnY, 0);

        // Enemy를 생성합니다.
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}
