using System;
using UnityEngine;

namespace Task2
{   
    public enum PlaceType
    {
        REST_PLACE = 0,
        WORK_PLACE = 1
    }

    public class Place : MonoBehaviour
    {
        [SerializeField] private PlaceType _placeType;

        public PlaceType PlaceType => _placeType;
    }
}