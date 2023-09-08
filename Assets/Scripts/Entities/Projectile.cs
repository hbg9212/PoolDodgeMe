using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10.0f; // 발사체 속도
    public float lifetime = 2.0f; // 발사체 수명 (예: 2초)


    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        Destroy(gameObject, lifetime);

    }

    // 발사체가 어떤 조건에서 삭제되어야 할지를 추가할 수도 있습니다.
    // 예를 들어, 충돌하면 삭제하는 로직을 추가할 수 있습니다.
}
