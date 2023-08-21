using System;
using UnityEngine;

[Serializable]
public class SpeedRunningStateConfig 
{
    [SerializeField, Range(10.1f, 20)] private float _speedRunningSpeed;

    public float SpeedRunningSpeed => _speedRunningSpeed;
}
