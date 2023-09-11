using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowBall : MonoBehaviour
{
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Init(float speed, Vector2 dir)
    {
        _rigidbody.velocity = dir * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall") || collision.CompareTag("Enemy"))
        {
            gameObject.SetActive(false);
        }
        else if(collision.CompareTag("Trap"))
        {
            if(collision.GetComponent<Trap>()._IsTrap)
            {
                gameObject.SetActive(false);
            }
        }
          
    }
}
