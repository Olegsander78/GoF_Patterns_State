using System;
using UnityEngine;

namespace Task2
{
    [Serializable]
    public class SmokingStateConfig
    {
        [SerializeField, Range(0, 100)] private float _smokingTime;

        public float SmokingTime => _smokingTime;
    }
}