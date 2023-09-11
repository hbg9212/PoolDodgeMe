using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //상하좌우 생성 채크
    private bool _IsLeft = true;
    private bool _IsUp = true;

    //좌우 생성 함수
    public void SpawnLeft()
    {
        if(_IsLeft)
        {
            _IsLeft = false;
            Transform enemy = PoolManager.I.Get((int)PoolManager.PrefabId.Enemy).transform;
            enemy.position = new Vector3(13, 0, 0);
            enemy.GetComponent<Enemy>().Init();
        }
        else
        {
            _IsLeft = true;
            Transform enemy = PoolManager.I.Get((int)PoolManager.PrefabId.Enemy).transform;
            enemy.position = new Vector3(-13, 0, 0);
            enemy.GetComponent<Enemy>().Init();
        }
    }

    //상하 생성 함수
    public void SpawnUp()
    {
        if (_IsUp)
        {
            _IsUp = false;
            Transform enemy = PoolManager.I.Get((int)PoolManager.PrefabId.Enemy).transform;
            enemy.position = new Vector3(0, 7, 0);
            enemy.GetComponent<Enemy>().Init();
        }
        else
        {
            _IsUp = true;
            Transform enemy = PoolManager.I.Get((int)PoolManager.PrefabId.Enemy).transform;
            enemy.position = new Vector3(0, -7, 0);
            enemy.GetComponent<Enemy>().Init();
        }
    }

    //좌우 모두 생성
    public void SpawnLeftRight()
    {
        Transform L = PoolManager.I.Get((int)PoolManager.PrefabId.Enemy).transform;
        L.position = new Vector3(13, 0, 0);
        L.GetComponent<Enemy>().Init();
        Transform R = PoolManager.I.Get((int)PoolManager.PrefabId.Enemy).transform;
        R.position = new Vector3(-13, 0, 0);
        R.GetComponent<Enemy>().Init();
    }

    //상하 모두 생성
    public void SpawnUpDown()
    {
        Transform U = PoolManager.I.Get((int)PoolManager.PrefabId.Enemy).transform;
        U.position = new Vector3(0, 7, 0);
        U.GetComponent<Enemy>().Init();
        Transform D = PoolManager.I.Get((int)PoolManager.PrefabId.Enemy).transform;
        D.position = new Vector3(0, -7, 0);
        D.GetComponent<Enemy>().Init();
    }

    //상하좌우 모두 생성
    public void SpawnAll()
    {
        Transform L = PoolManager.I.Get((int)PoolManager.PrefabId.Enemy).transform;
        L.position = new Vector3(13, 0, 0);
        L.GetComponent<Enemy>().Init();
        Transform R = PoolManager.I.Get((int)PoolManager.PrefabId.Enemy).transform;
        R.position = new Vector3(-13, 0, 0);
        R.GetComponent<Enemy>().Init();
        Transform U = PoolManager.I.Get((int)PoolManager.PrefabId.Enemy).transform;
        U.position = new Vector3(0, 7, 0);
        U.GetComponent<Enemy>().Init();
        Transform D = PoolManager.I.Get((int)PoolManager.PrefabId.Enemy).transform;
        D.position = new Vector3(0, -7, 0);
        D.GetComponent<Enemy>().Init();
    }
}
