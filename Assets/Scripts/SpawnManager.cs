using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject obstaclePrefab;
    [SerializeField] private float startDelay = 2.0f;
    [SerializeField] private float repeatRate = 2.0f;

    private Vector3 _spawnPosition = new Vector3(30, 0, 0);
    private PlayerController _playerController;

    private void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
        _playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    private void SpawnObstacle()
    {
        if (!_playerController.isGameOver)
        {
            Instantiate(obstaclePrefab, _spawnPosition, obstaclePrefab.transform.rotation);
        }
    }
}
