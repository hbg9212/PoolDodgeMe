using UnityEngine;

public class ItemCollisionHandler : MonoBehaviour
{
    private bool hasCollided = false; // 한 번 충돌했는지 여부를 나타내는 플래그

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!hasCollided && collision.CompareTag("Player"))
        {
            // 플레이어와 아이템이 충돌하면 화면 내 모든 적의 발사체를 삭제하는 로직을 추가합니다.
            Debug.Log("플레이어와 아이템 충돌!");
            DestroyAllProjectiles();

            // 아이템을 파괴하고, 다시 충돌하지 않도록 플래그를 설정합니다.
            Destroy(gameObject);
            hasCollided = true;
        }
    }

    private void DestroyAllProjectiles()
    {
        // 화면 내 모든 발사체를 찾아서 삭제하는 로직을 추가합니다.
        Projectile[] projectiles = FindObjectsOfType<Projectile>();
        foreach (Projectile projectile in projectiles)
        {
            Destroy(projectile.gameObject);
        }
    }
}
