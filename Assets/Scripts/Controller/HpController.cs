using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpController : MonoBehaviour
{
    public static HpController I;
    private void Awake()
    {
        I = this;
    }

    public Slider mySlider;

    public float _MaxHp;
    public float _Hp;

    public void SetHp(float hp)
    {
        _MaxHp = hp;
        _Hp = hp;
        mySlider.value = _Hp / _MaxHp;
    }

    public void CallHpAdd(float damage)
    {
        if (_Hp + damage <= _MaxHp)
        {
            _Hp += damage;
        }

        if(_Hp + damage <= 0)
        {
            mySlider.value = 0;
            GameManager.I._IsPlay = false;
        }
        else
        {
            mySlider.value = _Hp / _MaxHp;
        }
  
    }
}
