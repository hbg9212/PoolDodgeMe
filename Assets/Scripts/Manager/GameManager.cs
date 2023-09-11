using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private float _Seconds;
    private int _Minutes;
    public TMP_Text _TimeText;

    private void Awake()
    {
        Instance = this;
   
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
    }

    void Update()
    {
        UpdateTimer();
    }

    void UpdateTimer()
    {
        _Seconds += Time.deltaTime;

        _TimeText.text = string.Format($"{(int)_Minutes:D2}:{(int)_Seconds:D2}");

        if ((int)_Seconds > 59)
        {
            _Seconds = 0f;
            _Minutes++;
        }
    }

    IEnumerator Trpas()
    {
        while(true)
        {
            yield return new WaitForSeconds(Random.Range(1f, 2f));
            Transform trap = PoolManager.I.Get((int)PoolManager.PrefabId.Trap).transform;
            trap.position = new Vector3(-27,0,0);
            trap.GetComponent<Trap>().GetPosition();
        }
    }

    IEnumerator Bombs()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1f, 2f));
            Transform bomb = PoolManager.I.Get((int)PoolManager.PrefabId.Bomb).transform;
            bomb.position = new Vector3(-27, 0, 0);
            bomb.GetComponent<ItemBomb>().GetPosition();
        }
    }
}
