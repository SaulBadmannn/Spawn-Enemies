using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMonsters : MonoBehaviour
{
    [SerializeField] private GameObject _monster;
    [SerializeField] private Transform _allSpawns;
    private Transform[] _spawns;
    private Random _rand = new Random();
    private int _amountMonsters = 8;

    private void Start()
    {
        _spawns = new Transform[_allSpawns.childCount];

        for (int i = 0; i < _allSpawns.childCount; i++)
        {
            _spawns[i] = _allSpawns.GetChild(i);
        }

        var createMonsters = CreateMonsters();
        StartCoroutine(createMonsters);
    }

    private IEnumerator CreateMonsters()
    {
        for (int i = 0; i < _amountMonsters; i++)
        {
            Vector3 spawnPoint = _spawns[Random.Range(0, _spawns.Length)].position;
            Instantiate(_monster, spawnPoint, Quaternion.identity);
            yield return new WaitForSeconds(2);
        }
    }
}
