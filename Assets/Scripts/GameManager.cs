using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager I;



    private void Awake()
    {
        I = this;

    }

    public TMP_Text TimeTxt;
    private float _Sec;
    private int _Min;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        Timer();
    }

    void Timer()
    {
        _Sec += Time.deltaTime;

        TimeTxt.text = string.Format($"{_Min:D2}:{(int)_Sec:D2}");

        if((int)_Sec > 59)
        {
            _Sec = 0f;
            _Min++;
        }

    }
}
