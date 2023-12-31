using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager I;
    private EnemySpawner enemySpawner;
    private void Awake()
    {
        I = this;
        enemySpawner = GetComponent<EnemySpawner>();
    }

    public GameObject GameOver;
    public GameObject Player;
    public TMP_Text TimeTxt;
    private float _Sec;
    private int _Min;

    public bool _IsPlay = false;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        HpController.I.SetHp(100f);
        _IsPlay = true;
        StartCoroutine(Trpas());
        StartCoroutine(Bombs());
        StartCoroutine(Hearts());
        StartCoroutine(Ice());
        AudioManager.I.PlayBgm(true);
        enemySpawner.SpawnLeftRight();
        StartCoroutine(SpawnLeft());
        StartCoroutine(SpawnUp());
        StartCoroutine(SpawnAll());
    }

    void Update()
    {
        if(_IsPlay)
        {
            Timer();
        }
        else
        {
            GameOver.SetActive(true);
            Time.timeScale = 0;
        }
    }

    void Timer()
    {
        _Sec += Time.deltaTime;

        TimeTxt.text = string.Format($"{_Min:D2}:{(int)_Sec:D2}");

        if ((int)_Sec > 59)
        {
            _Sec = 0f;
            _Min++;
        }
    }

    IEnumerator SpawnLeft()
    {
        while (_IsPlay)
        {
            yield return new WaitForSeconds(10f);

            enemySpawner.SpawnLeft();
        }
    }

    IEnumerator SpawnUp()
    {
        while (_IsPlay)
        {
            yield return new WaitForSeconds(30f);
            enemySpawner.SpawnUp();
        }
    }

    IEnumerator SpawnAll()
    {
        while (_IsPlay)
        {
            yield return new WaitForSeconds(60f);
            enemySpawner.SpawnBoss(50*_Min, (1f+_Min));
            enemySpawner.SpawnAll();
        }
    }

    IEnumerator Trpas()
    {
        while(_IsPlay)
        {
            yield return new WaitForSeconds(Random.Range(1f, 2f));

            if (PoolManager.I.GetComponentsInChildren<Trap>().Length < 20)
            {
                Transform trap = PoolManager.I.Get((int)PoolManager.PrefabId.Trap).transform;
                trap.position = new Vector3(-27, 0, 0);
                trap.GetComponent<Trap>().GetPosition();
            }
        }
    }

    IEnumerator Bombs()
    {
        while (_IsPlay)
        {
            yield return new WaitForSeconds(Random.Range(1f, 2f));

            if(PoolManager.I.GetComponentsInChildren<ItemBomb>().Length < 3)
            {
                Transform bomb = PoolManager.I.Get((int)PoolManager.PrefabId.Bomb).transform;
                bomb.position = new Vector3(-27, 0, 0);
                bomb.GetComponent<ItemBomb>().GetPosition();
            }
        }
    }
    IEnumerator Hearts()
    {
        while (_IsPlay)
        {
            yield return new WaitForSeconds(Random.Range(1f, 2f));

            if (PoolManager.I.GetComponentsInChildren<ItemHeart>().Length < 3)
            {
                Transform heart = PoolManager.I.Get((int)PoolManager.PrefabId.Heart).transform;
                heart.position = new Vector3(-27, 0, 0);
                heart.GetComponent<ItemHeart>().GetPosition();
            }
        }
    }

    IEnumerator Ice()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1f, 2f));

            if (PoolManager.I.GetComponentsInChildren<ItemIce>().Length < 3)
            {
                Transform ice = PoolManager.I.Get((int)PoolManager.PrefabId.Ice).transform;
                ice.position = new Vector3(-27, 0, 0);
                ice.GetComponent<ItemIce>().GetPosition();
            }
        }
    }



}
