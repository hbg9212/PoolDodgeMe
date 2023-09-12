using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHeart : MonoBehaviour
{
    private Animator _anim;

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
        _anim = GetComponent<Animator>();
        transform.position = new Vector3(_positionX - 9, _positionY - 3, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(Heart());
        }
    }

    IEnumerator Heart()
    {
        yield return new WaitForSeconds(0.4f);
        SpawnerManager.I.SetSpawner(_positionX, _positionY, 0);
        gameObject.SetActive(false);
    }
}
