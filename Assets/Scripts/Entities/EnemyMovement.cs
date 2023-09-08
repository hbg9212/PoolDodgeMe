using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 5.0f; // Enemy 이동 속도
    private Vector3 moveDirection; // 이동 방향
    private float minX = -8.0f; // 화면 왼쪽 경계
    private float maxX = 8.0f; // 화면 오른쪽 경계
    private float minY = -3.0f; // 화면 아래쪽 경계
    private float maxY = 3.0f; // 화면 위쪽 경계

    private void Start()
    {
        // 초기 이동 방향 설정
        SetRandomMoveDirection();
    }

    private void Update()
    {
        MoveEnemy();
        CheckScreenBounds();
    }

    private void MoveEnemy()
    {
        // Enemy를 현재 이동 방향과 속도를 사용하여 이동합니다.
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }

    private void SetRandomMoveDirection()
    {
        // 랜덤한 방향 벡터를 설정합니다.
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        moveDirection = new Vector3(randomX, randomY, 0).normalized;
    }

    public void SetMoveDirection(Vector3 direction)
    {
        moveDirection = direction.normalized;
    }

    private void CheckScreenBounds()
    {
        // 화면 경계에 도달하면 랜덤한 이동 방향을 다시 설정합니다.
        Vector3 position = transform.position;

        if (position.x < minX || position.x > maxX || position.y < minY || position.y > maxY)
        {
            SetRandomMoveDirection();
        }
    }
}
