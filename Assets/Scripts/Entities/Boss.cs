using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private Animator _anim;
    private Rigidbody2D _target;

    public Slider mySlider;

    private int _MaxHp;

    private int _Hp;
    private float _Speed;
    private bool _IsHit = false;

    public void Init(int hp, float speed)
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _target = GameManager.I.Player.GetComponent<Rigidbody2D>();
        _MaxHp = hp;
        _Hp = hp;
        _Speed = speed;
        mySlider.value = _Hp / _MaxHp;
    }

    void FixedUpdate()
    {
        if (_IsHit)
        {
            _rigidbody.velocity = (_target.position - _rigidbody.position) * -2;
        }
        else
        {
            _rigidbody.velocity = (_target.position - _rigidbody.position) * _Speed;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("SnowBall"))
            return;
        _anim.SetTrigger("Hit");
        _IsHit = true;
        StartCoroutine(Hit());
        _Hp--;
        mySlider.value = (float)_Hp / (float)_MaxHp;
        if (_Hp == 0)
        {
            gameObject.SetActive(false);
        }
    }

    IEnumerator Hit()
    {
        yield return new WaitForSeconds(0.1f);
        _IsHit = false;
    }
}