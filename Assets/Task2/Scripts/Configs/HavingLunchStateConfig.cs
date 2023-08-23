using System;
using UnityEngine;

namespace Task2
{
    [Serializable]
    public class HavingLunchStateConfig
    {
        [SerializeField, Range(0, 100)] private float _havingLunchTime;

        public float HavingLunchTime => _havingLunchTime;
    }
}