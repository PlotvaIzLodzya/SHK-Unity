using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerInput), typeof(Player))]
public class PlayerMover : MonoBehaviour
{
    private PlayerInput _playerInput;
    private Player _player;

    private void Start()
    {
        _player = GetComponent<Player>();
    }

    private void OnEnable()
    {
        _playerInput = GetComponent<PlayerInput>();
        _playerInput.ButtonPressed += Move;
    }

    private void OnDisable()
    {
        _playerInput.ButtonPressed -= Move;
    }

    private void Move(Vector2 direction)
    {
        transform.Translate(direction * _player.Speed * Time.deltaTime);
    }
}
