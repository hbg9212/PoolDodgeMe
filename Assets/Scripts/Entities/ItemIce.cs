using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemIce : MonoBehaviour
{
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
        transform.position = new Vector3(_positionX - 9, _positionY - 3, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!_IsTrigger) return;

        if (collision.CompareTag("Player"))
        {
            _IsTrigger = false;

            if (collision.CompareTag("Player"))
            {
                _IsTrigger = false;
                Enemy[] E = PoolManager.I.GetComponentsInChildren<Enemy>();
                if (E.Length > 0)
                {
                    foreach (Enemy e in E)
                    {
                        e._IsFire = false;
                        e._IsFreez = true;
                        e._anim.SetTrigger("Freez");
                    }
                }
                AudioManager.I.PlaySfx(AudioManager.Sfx.Freez);
                gameObject.SetActive(false);

            }
        }
    }

    IEnumerator DeactivateItem()
    {
        yield return new WaitForSeconds(0.4f);
        SpawnerManager.I.SetSpawner(_positionX, _positionY, 0);
        gameObject.SetActive(false);
    }
}
