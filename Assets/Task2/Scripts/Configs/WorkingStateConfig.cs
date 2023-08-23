using System;
using UnityEngine;

namespace Task2
{
    [Serializable]
    public class WorkingStateConfig
    {
        [SerializeField, Range(0, 100)] private float _workingTime;

        public float WorkingTime => _workingTime;
    }
}