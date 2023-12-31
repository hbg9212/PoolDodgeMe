using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBomb : MonoBehaviour
{
    private Animator _anim;

    private int _positionX;
    private int _positionY;

    private bool _IsTrigger = true;

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
        _IsTrigger = true;
        _anim = GetComponent<Animator>();
        transform.position = new Vector3(_positionX - 9, _positionY - 3, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!_IsTrigger) return;

        if (collision.CompareTag("Player"))
        {
            _IsTrigger = false;
            Bomb[] b = PoolManager.I.GetComponentsInChildren<Bomb>();
            if(b.Length > 0)
            {
                foreach (Bomb g in b)
                {
                    g.gameObject.SetActive(false);
                }
            }
            AudioManager.I.PlaySfx(AudioManager.Sfx.Bomb);
            _anim.SetTrigger("Bomb");
            StartCoroutine(Bomb());
        }
    }

    IEnumerator Bomb()
    {
        yield return new WaitForSeconds(0.4f);
        SpawnerManager.I.SetSpawner(_positionX, _positionY, 0);
        gameObject.SetActive(false);
    }
}
