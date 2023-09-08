using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject projectilePrefab; // 발사체 프리팹
    public Transform shootingPoint; // 발사 위치
    public float shootInterval = 2.0f; // 발사 주기
    public float projectileSpeed = 10.0f; // 발사체 속도
    private Transform player; // Player 오브젝트
    //private float timeSinceLastShot = 0.0f;

    private void Start()
    {
        // Player 오브젝트를 찾아 저장합니다.
        player = GameObject.FindGameObjectWithTag("Player").transform;

        // 일정 주기로 ShootAtPlayer 함수를 호출합니다.
        InvokeRepeating("ShootAtPlayer", 0, shootInterval);
    }

    private void ShootAtPlayer()
    {
        if (player != null)
        {
            // Player와 Enemy 사이의 방향 벡터를 계산합니다.
            Vector3 directionToPlayer = (player.position - shootingPoint.position).normalized;

            // 발사체를 생성하고 초기 속도를 설정합니다.
            GameObject projectile = Instantiate(projectilePrefab, shootingPoint.position, Quaternion.identity);
            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
            rb.velocity = directionToPlayer * projectileSpeed;
        }
    }
}

