using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;

public class GameFlow : MonoBehaviour
{
    [SerializeField] private GameObject EndScreen;
    [SerializeField] private Player _player;

    private List<Enemy> _enemies;
    private int _deadEnemyCounter = 0;

    public event UnityAction AllEnemyDead;

    private void Start()
    {
        _enemies = FindObjectsOfType<Enemy>().ToList();

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

        if (_deadEnemyCounter >= _enemies.Count)
        {
            AllEnemyDead?.Invoke();
        }
    }
}
