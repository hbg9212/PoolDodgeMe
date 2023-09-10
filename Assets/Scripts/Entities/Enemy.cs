using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private Animator _anim;

    public GameObject Bullet;
    public Vector3 Dir;

    private bool _IsFire = false;
    private bool _IsFreez = false;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Vector3 targetPos = GameManager.I.Player.transform.position;
        Vector3 dir = targetPos - transform.position;
        if(Mathf.Abs(dir.x) > 12)
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
        if(transform.position.x > 0)
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
            else if(_IsFreez)
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
        if(!_IsFreez)
        {
            _IsFire = false;
            _IsFreez = true;
            _anim.SetTrigger("Freez");
        }
    }

    private void Fire()
    {
        if(_IsFire)
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
