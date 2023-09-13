using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHeart : MonoBehaviour
{

    private int _positionX;
    private int _positionY;

    public void GetPosition()
    {
        _positionX = Random.Range(0, 19);
        _positionY = Random.Range(0, 7);

        if (SpawnerManager.I.GetSpawner(_positionX, _positionY) == 0)
        {
            SpawnerManager.I.SetSpawner(_positionX, _positionY, 1);
            Init();
        }
        else
        {
            GetPosition();
        }
    }

    private void Init()
    {
        transform.position = new Vector3(_positionX - 9, _positionY - 3, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if(HpController.I._MaxHp > HpController.I._Hp)
            {
                HpController.I.CallHpAdd(10f);
                AudioManager.I.PlaySfx(AudioManager.Sfx.Heal);
                gameObject.SetActive(false);
            }

        }
    }
}