using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Tuna_Library
{
    public static void JoystickMove(float _hor, float _ver, Transform player, float _moveSpeed = 1f)
    {
        player.position += new Vector3(_hor * Time.deltaTime, 0f, _ver * Time.deltaTime) * _moveSpeed;
    }

    public static void JoystickRotate(float _hor, float _ver, Transform player)
    {
        player.eulerAngles = new Vector3(0, Mathf.Atan2(_ver, -_hor) * 180 / Mathf.PI - 90f, 0f);
    }
}
