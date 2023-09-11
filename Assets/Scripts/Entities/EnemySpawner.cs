using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //�����¿� ���� äũ
    private bool _IsLeft = true;
    private bool _IsUp = true;

    //�¿� ���� �Լ�
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

    //���� ���� �Լ�
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

    //�¿� ��� ����
    public void SpawnLeftRight()
    {
        Transform L = PoolManager.I.Get((int)PoolManager.PrefabId.Enemy).transform;
        L.position = new Vector3(13, 0, 0);
        L.GetComponent<Enemy>().Init();
        Transform R = PoolManager.I.Get((int)PoolManager.PrefabId.Enemy).transform;
        R.position = new Vector3(-13, 0, 0);
        R.GetComponent<Enemy>().Init();
    }

    //���� ��� ����
    public void SpawnUpDown()
    {
        Transform U = PoolManager.I.Get((int)PoolManager.PrefabId.Enemy).transform;
        U.position = new Vector3(0, 7, 0);
        U.GetComponent<Enemy>().Init();
        Transform D = PoolManager.I.Get((int)PoolManager.PrefabId.Enemy).transform;
        D.position = new Vector3(0, -7, 0);
        D.GetComponent<Enemy>().Init();
    }

    //�����¿� ��� ����
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
