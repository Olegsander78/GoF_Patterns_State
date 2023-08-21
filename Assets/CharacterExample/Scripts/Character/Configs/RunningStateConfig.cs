using System;
using UnityEngine;

[Serializable]
public class RunningStateConfig
{
    [SerializeField, Range(5.1f, 10)] private float _runningSpeed;

    public float RunningSpeed => _runningSpeed;
}
