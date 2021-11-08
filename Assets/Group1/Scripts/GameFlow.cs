using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameFlow : MonoBehaviour
{
    [SerializeField] private GameObject EndScreen;
    [SerializeField] private Enemy[] _enemies;
    [SerializeField] private Player _player;

    private int _deadEnemyCounter = 0;

    public event UnityAction AllEnemyDead;

    private void Start()
    {
        foreach (var enemy in _enemies)
        {
            enemy.Died += UpdateDeadEnemyCounter;
        }
    }

    private void OnEnable()
    {
        AllEnemyDead += End;
    }

    private void OnDisable()
    {
        AllEnemyDead -= End;
    }

    private void End()
    {
        _player.gameObject.SetActive(false);
        EndScreen.SetActive(true);
    }

    private void UpdateDeadEnemyCounter(Enemy enemy)
    {
        _deadEnemyCounter++;

        enemy.Died -= UpdateDeadEnemyCounter;

        if (_deadEnemyCounter >= _enemies.Length)
        {
            AllEnemyDead?.Invoke();
        }
    }
}
