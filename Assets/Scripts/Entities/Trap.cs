using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    private int _positionX;
    private int _positionY;

    public bool _IsTrap = false;

    public void GetPosition()
    {
        _IsTrap = false;
        _positionX = Random.Range(0, 19);
        _positionY = Random.Range(0, 7);

        if(SpawnerManager.I.GetSpawner(_positionX, _positionY) == 0)
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
        transform.position = new Vector3(_positionX-9,_positionY-3,0);
        StartCoroutine(SetPoop());
    }

    IEnumerator SetPoop()
    {
        yield return new WaitForSeconds(1.5f);
        _IsTrap = true;
        transform.GetComponent<SpriteRenderer>().enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(_IsTrap)
        {
            if (collision.CompareTag("Player") || collision.CompareTag("SnowBall"))
            {
                SpawnerManager.I.SetSpawner(_positionX, _positionY, 0);
                gameObject.SetActive(false);
                transform.GetComponent<SpriteRenderer>().enabled = false;
                if (collision.CompareTag("Player"))
                {
                    AudioManager.I.PlaySfx(AudioManager.Sfx.Hit);
                    HpController.I.CallHpAdd(-10f);
                }
            }
        }
    }
}
