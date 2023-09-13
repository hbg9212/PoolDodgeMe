using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Init(float speed, Vector3 dir)
    {
        _rigidbody.velocity = dir * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall"))
        {
            gameObject.SetActive(false); // 벽과 충돌 시 발사한 객체 비활성화
        }
        else if (collision.CompareTag("Player"))
        {
            // Player와 충돌한 경우
            gameObject.SetActive(false); // 발사한 객체를 비활성화
        }
    }
}
