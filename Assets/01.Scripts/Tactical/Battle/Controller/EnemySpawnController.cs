using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[Serializable]
public class EnemyWave
{
    public EnemySO[] enemySOs;

    public EnemySO EnemySO => enemySOs[Random.Range(0, enemySOs.Length)];
}

public class EnemySpawnController : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    
    [Header("Waves")]
    [SerializeField] private List<EnemyWave> enemyWave;
    [SerializeField] private float[] spawnTimes;
    
    [Header("Offset")]
    [SerializeField] private Vector3[] offsetSpawnPoints;
    
    private float _spawnTime;
    private int _currentWave;

    private void Start()
    {
        _currentWave = 0;
    }

    private void Update()
    {
        _spawnTime -= Time.deltaTime;
        if (_spawnTime <= 0)
        {
            _spawnTime = spawnTimes[_currentWave];
            Spawn();
        }
    }

    private void Spawn()
    {
        var spawnPoint = BattleController.Inst.player.transform.position + offsetSpawnPoints[Random.Range(0, offsetSpawnPoints.Length)];
        var enemy = Instantiate(enemyPrefab, spawnPoint, Quaternion.identity);
        enemy.GetComponent<Enemy>().Initialize(enemyWave[_currentWave].EnemySO);
        BattleController.Inst.healthBarController.Connect(enemy.gameObject);
    }
}
