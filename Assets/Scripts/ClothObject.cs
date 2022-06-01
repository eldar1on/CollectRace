using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothObject : MonoBehaviour
{

    public Transform _target;
    public float _speed;
    public int _ID;

    public enum DressType
    {
        Top,
        Bottom,
        Complete,
        Shoe,
        Hair,
    }
    public DressType _style;


    TargetSuit _tSuit;

    public void Start()
    {
        transform.LookAt(_target);
        //print("Hello");
    }

    [Header("Lerp")]
    public int interpolationFramesCount = 20; // Number of frames to completely interpolate between the 2 positions
    public int elapsedFrames = 0;
    public bool _shrink;
    public Vector3 _endPos;

    public void Update()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
        /*
        if (_shrink)
        {
            float interpolationRatio = (float)elapsedFrames / interpolationFramesCount;

            Vector3 interpolatedPos = Vector3.Lerp(transform.position, _endPos, interpolationRatio);

            if (elapsedFrames == interpolationFramesCount)
            {
                _shrink = false;
            }

            elapsedFrames = (elapsedFrames + 1) % (interpolationFramesCount + 1);
            transform.localPosition = interpolatedPos;
        }
        */


    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Model")
        {
            _tSuit = other.gameObject.GetComponent<TargetSuit>();
            _tSuit.ChangePart(this);
            Destroy(gameObject);
        }
    }
}
