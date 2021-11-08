using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _boostTime;
    [SerializeField] private float _speedBoost;

    public float Speed => _speed;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent(out SpeedBooster speedBooster))
            StartCoroutine(BoostSpeedTimer());
    }

    private void ChangeSpeed(float multiplier)
    {
        _speed += multiplier;
    }

    private IEnumerator BoostSpeedTimer()
    {
        ChangeSpeed(_speedBoost);
        yield return new WaitForSeconds(_boostTime);
        ChangeSpeed(-_speedBoost);
    }
}
