using System;
using UnityEngine;

namespace Task2
{
    [Serializable]
    public class RestingStateConfig
    {
        [SerializeField, Range(0, 100)] private float _restingTime;

        public float RestingTime => _restingTime; 
    }
}