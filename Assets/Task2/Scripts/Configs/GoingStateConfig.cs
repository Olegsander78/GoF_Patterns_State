using System;
using UnityEngine;

namespace Task2
{
    [Serializable]
    public class GoingStateConfig
    {
        [SerializeField, Range(0, 20)] private float _goingSpeed;

        public float GoingSpeed => _goingSpeed;
    }
}