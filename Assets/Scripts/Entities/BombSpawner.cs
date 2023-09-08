using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject itemBombPrefab; // 폭탄 아이템 프리팹
    public float initialDelay = 5.0f; // 초기 지연 시간 (5초)
    public float spawnInterval = 5.0f; // 아이템 생성 간격 (5초로 설정)
    private Camera mainCamera; // 메인 카메라 참조

    private void Start()
    {
        // 메인 카메라를 찾아 저장합니다.
        mainCamera = Camera.main;

        // 초기 지연 시간 후부터 일정 주기마다 아이템을 생성하는 함수 호출
        InvokeRepeating("SpawnItems", initialDelay, spawnInterval);
    }

    private void SpawnItems()
    {
        // x와 y 좌표를 랜덤하게 설정합니다.
        float randomX = Random.Range(-8f, 8f);
        float randomY = Random.Range(-3f, 3f);

        // 아이템을 생성합니다.
        Vector3 spawnPosition = new Vector3(randomX, 0, randomY);
        GameObject itemBomb = Instantiate(itemBombPrefab, spawnPosition, Quaternion.identity);

        // 아이템과 플레이어의 충돌을 감지하기 위해 Collider2D 컴포넌트를 추가합니다.
        Collider2D itemCollider = itemBomb.GetComponent<Collider2D>();
        if (itemCollider != null)
        {
            // 아이템과 플레이어의 충돌을 감지하는 스크립트를 추가합니다.
            itemCollider.isTrigger = true;
            itemCollider.gameObject.AddComponent<ItemCollisionHandler>();
        }
    }
}
