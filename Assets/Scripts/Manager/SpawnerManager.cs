using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    public static SpawnerManager I;

    private void Awake()
    {
        I = this;
    }

    private int[,] SpawnerPosition = new int[19, 7];

    public int GetSpawner(int x, int y)
    {
        return SpawnerPosition[x, y];
    }

    public void SetSpawner(int x, int y, int i)
    {
        SpawnerPosition[x, y] = i;
    }

}
