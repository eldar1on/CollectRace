using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Joystick _joystick;
    public float _speed;
    public GameObject playerArrow;
    public Animator _animator;

    public bool takeInput;

    private void OnEnable()
    {
        gameManager.OnWin += EventTrigger;
    }
    private void OnDisable()
    {
        gameManager.OnWin -= EventTrigger;
    }



    void Update()
    {
        if (takeInput)
        {
            if (Mathf.Abs(_joystick.Horizontal) >= 0.1f || Mathf.Abs(_joystick.Vertical) >= 0.1f)
            {
                Tuna_Library.JoystickMove(_joystick.Horizontal, _joystick.Vertical, transform, _speed);
                _animator.SetFloat("Speed", Mathf.Max(Mathf.Abs(_joystick.Horizontal), Mathf.Abs(_joystick.Vertical)));

                Tuna_Library.JoystickRotate(_joystick.Horizontal, _joystick.Vertical, transform);

            }
            else
            {
                //animType = AnimType.Idle;
                _animator.SetBool("Walkin", false);
                _animator.SetFloat("Speed", 0f);
            }
        }
        else
        {
            playerArrow.SetActive(false);
        }

    }

    public void EventTrigger()
    {
        if (takeInput)
            takeInput = false;

    }
}
