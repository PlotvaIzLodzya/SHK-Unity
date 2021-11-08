using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    private Vector3 _target;
    private float _radius = 4f;
    private float _speed = 2f;

    public event UnityAction<Enemy> Died;

    private void Start()
    {
        _target = Random.insideUnitCircle * _radius;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target, _speed * Time.deltaTime);

        if (transform.position == _target)
            _target = Random.insideUnitCircle * _radius;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
            Die();
    }

    private void Die()
    {
        Died?.Invoke(this);
        Destroy(gameObject);
    }
}
