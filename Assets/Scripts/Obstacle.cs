using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{

    public enum DressType
    {
        Top,
        Bottom,
        Complete,
        Shoe,
        Hair,
    }

    public DressType myDress;
    public int dressID;
    private BoxCollider _collider;

    [Header("Lerp")]
    public int interpolationFramesCount = 20; // Number of frames to completely interpolate between the 2 positions
    public int elapsedFrames = 0;
    public bool _shrink;
    public bool _inflate;

    void Awake()
    {
        _collider = GetComponent<BoxCollider>();
    }


    void Update()
    {
        if (_shrink)
        {
            Shrink();
        }
        if (_inflate)
        {
            Inflate();
        }
    }

    void Shrink()
    {
        _collider.enabled = false;

        float interpolationRatio = (float)elapsedFrames / interpolationFramesCount;

        Vector3 interpolatedScale = Vector3.Lerp(Vector3.one, Vector3.zero, interpolationRatio);

        if (elapsedFrames == interpolationFramesCount)
        {
            _shrink = false;
            _inflate = true;
        }

        elapsedFrames = (elapsedFrames + 1) % (interpolationFramesCount + 1);

        transform.localScale = interpolatedScale;
    }

    void Inflate()
    {
        float interpolationRatio = (float)elapsedFrames / interpolationFramesCount;

        Vector3 interpolatedScale = Vector3.Lerp(Vector3.zero, Vector3.one, interpolationRatio);

        if (elapsedFrames == interpolationFramesCount)
        {
            _inflate = false;
            _collider.enabled = true;
        }

        elapsedFrames = (elapsedFrames + 1) % (interpolationFramesCount + 1);

        transform.localScale = interpolatedScale;
    }

}
