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


    public GameObject Player;
    public TMP_Text TimeTxt;
    private float _Sec;
    private int _Min;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Trpas());
        StartCoroutine(Bombs());
        AudioManager.I.PlayBgm(true);
        enemySpawner.SpawnLeftRight();
        StartCoroutine(SpawnLeft());
        StartCoroutine(SpawnUp());
        StartCoroutine(SpawnAll());
    }

    void Update()
    {
        Timer();
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
        while (true)
        {
            yield return new WaitForSeconds(10f);

            enemySpawner.SpawnLeft();
        }
    }

    IEnumerator SpawnUp()
    {
        while (true)
        {
            yield return new WaitForSeconds(30f);
            enemySpawner.SpawnUp();
        }
    }

    IEnumerator SpawnAll()
    {
        while (true)
        {
            yield return new WaitForSeconds(60f);
            enemySpawner.SpawnBoss(50*_Min, (1f+_Min));
            enemySpawner.SpawnAll();
        }
    }

    IEnumerator Trpas()
    {
        while(true)
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
        while (true)
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
}
