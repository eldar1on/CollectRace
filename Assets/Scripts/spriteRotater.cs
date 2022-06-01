using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spriteRotater : MonoBehaviour
{
    public Transform _cam;

    private void Update()
    {
        transform.LookAt(_cam);
    }
}
