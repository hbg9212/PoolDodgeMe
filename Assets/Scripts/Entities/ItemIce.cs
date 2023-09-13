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

            //Enemy[] enemies = FindObjectsOfType<Enemy>();
            //foreach (Enemy enemy in enemies)
            //{
            //    enemy.PauseMovement(5.0f); 
            //}

            //Boss[] bosses = FindObjectsOfType<Boss>();
            //foreach (Boss boss in bosses)
            //{
            //    boss.PauseMovement(5.0f); 
            //}

            StartCoroutine(DeactivateItem());
        }
    }

    IEnumerator DeactivateItem()
    {
        yield return new WaitForSeconds(0.4f);
        SpawnerManager.I.SetSpawner(_positionX, _positionY, 0);
        gameObject.SetActive(false);
    }
}
