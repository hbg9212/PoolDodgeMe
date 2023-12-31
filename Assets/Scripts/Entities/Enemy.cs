using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    public Animator _anim;

    public GameObject Bullet;
    public Vector3 Dir;

    public bool _IsFire = false;
    public bool _IsFreez = false;

    // Start is called before the first frame update
    public void Init()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();

        Vector3 dir = Vector3.zero - transform.position;
        if (Mathf.Abs(dir.x) > 12)
        {
            dir = dir.normalized;
            Dir = new Vector3(dir.x, 0, 0);
            transform.localScale = new Vector3(dir.x, 1, 1);
        }
        else
        {
            dir = dir.normalized;
            Dir = new Vector3(0, dir.y, 0);
        }

        StartCoroutine(Move());
        StartCoroutine(Reload());
    }

    private void FixedUpdate()
    {
        if (transform.position.x > 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    IEnumerator Move()
    {
        while (true)
        {
            if (_IsFire)
            {
                _anim.SetTrigger("Fire");
                yield return new WaitForSeconds(2f);
                Fire();
            }
            else if (_IsFreez)
            {

                yield return new WaitForSeconds(2f);
                _IsFreez = false;
                StartCoroutine(Reload());
            }
            else
            {
                Vector2 direction;
                if (Dir.x == 0)
                {
                    direction = new Vector2(Random.Range(-3, 4), Random.Range(-0.5f, 0.6f));
                }
                else
                {
                    direction = new Vector2(Random.Range(-0.5f, 0.6f), Random.Range(-3, 4));
                }
                _rigidbody.velocity = direction;
                yield return new WaitForSeconds(2f);
            }
            yield return null;
        }
    }

    IEnumerator Reload()
    {
        yield return new WaitForSeconds(Random.Range(2f, 7f));
        _IsFire = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("SnowBall"))
            return;
        if (!_IsFreez)
        {
            AudioManager.I.PlaySfx(AudioManager.Sfx.Freez);
            _IsFire = false;
            _IsFreez = true;
            _anim.SetTrigger("Freez");
        }
    }

    private void Fire()
    {
        if (_IsFire)
        {
            Transform bullet = PoolManager.I.Get((int)PoolManager.PrefabId.Poop).transform;
            bullet.position = transform.position;
            bullet.GetComponent<Bullet>().Init(15f, Dir);
            AudioManager.I.PlaySfx(AudioManager.Sfx.Poop);
            _IsFire = false;
            StartCoroutine(Reload());
        }
    }
}