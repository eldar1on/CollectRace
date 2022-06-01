using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelAcitavor : MonoBehaviour
{
    [Header("Lerp")]
    public int interpolationFramesCount = 20; // Number of frames to completely interpolate between the 2 positions
    public int elapsedFrames = 0;
    public bool _shrink;
    public bool _step;

    public Vector3 _start, _end;

    void Update()
    {
        if (_step)
        {
            Step();
        }
    }

    void Step()
    {
        float interpolationRatio = (float)elapsedFrames / interpolationFramesCount;

        Vector3 interpolatedPos = Vector3.Lerp(_start, _end, interpolationRatio);

        if (elapsedFrames == interpolationFramesCount)
        {
            _step = false;
        }

        elapsedFrames = (elapsedFrames + 1) % (interpolationFramesCount + 1);

        transform.position = interpolatedPos;
    }

    public void SetUp()
    {
        _start = transform.position;
        _end = _start + new Vector3(0,0,-5f);
        _step = true;
        print("SetUp");
    }

    public void Activate()
    {
        TargetSuit _targetsuit = transform.GetChild(0).GetComponent<TargetSuit>();
        _targetsuit.enabled = true;
    }
}
