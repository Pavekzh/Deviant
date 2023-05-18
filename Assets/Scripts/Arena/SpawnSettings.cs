using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSettings : MonoBehaviour
{
    [SerializeField] GameObject[] SpawnersPosition;

    public Vector3 RandomSpawner()
    {
        return SpawnersPosition[Random.Range(0, SpawnersPosition.Length-1)].transform.position;
    }
}
