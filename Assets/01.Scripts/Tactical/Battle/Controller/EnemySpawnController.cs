using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[Serializable]
public class EnemyWave
{
    public EnemySO[] enemySOs;
    public float nextWaveTime;
    public float spawnTime;

    public EnemySO EnemySO => enemySOs[Random.Range(0, enemySOs.Length)];
}

public class EnemySpawnController : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    
    [Header("Waves")]
    [SerializeField] private List<EnemyWave> enemyWave;
    
    [Header("Offset")]
    [SerializeField] private Vector3[] offsetSpawnPoints;
    
    private float _spawnTime = 2;
    private int _currentWave;
    private float _waveTime = 15;

    private void Start()
    {
        _currentWave = 0;
        _spawnTime = 2;
    }

    private void Update()
    {
        _spawnTime -= Time.deltaTime;
        if (_spawnTime <= 0)
        {
            _spawnTime = enemyWave[_currentWave].spawnTime;
            Spawn();
        }

        _waveTime -= Time.deltaTime;
        if (_waveTime <= 0)
        {
            _waveTime = enemyWave[_currentWave].nextWaveTime;
            if(_currentWave < enemyWave.Count - 1)
                _currentWave++;
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
