using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    public event UnityAction<Vector2> ButtonPressed;

    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
            ButtonPressed?.Invoke(Vector2.up);

        if (Input.GetKey(KeyCode.S))
            ButtonPressed?.Invoke(Vector2.down);

        if (Input.GetKey(KeyCode.A))
            ButtonPressed?.Invoke(Vector2.left);

        if (Input.GetKey(KeyCode.D))
            ButtonPressed?.Invoke(Vector2.right);
    }
}
