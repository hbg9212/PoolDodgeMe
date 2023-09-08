using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_LR : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private Animator _anim;

    public GameObject Bullet;
    public Vector3 Dir;

    private bool _IsFire = false;

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
        dir = dir.normalized;
        Dir = new Vector3(dir.x, 0, 0);
        transform.localScale = new Vector3(dir.x, 1, 1);
        StartCoroutine(Move());
        StartCoroutine(Reload());
    }

    IEnumerator Move()
    {
        while (true)
        {
            if (_IsFire)
            {
                _anim.SetTrigger("Fire");
                yield return new WaitForSeconds(2f);
                _IsFire = false;
                Fire();
                StartCoroutine(Reload());
            }
            else
            {
                Vector2 direction = new Vector2(Random.Range(-0.5f, 0.6f), Random.Range(-3, 4));
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


    private void Fire()
    {
        GameObject bullet = Instantiate(Bullet, transform.position, Quaternion.identity);
        bullet.transform.rotation = Quaternion.FromToRotation(Vector3.up, Dir);
        bullet.GetComponent<Bullet>().Init(15f, Dir);
    }
}
