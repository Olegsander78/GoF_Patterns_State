using System;
using UnityEngine;

namespace Task2
{   
    public enum PlaceTypes
    {
        REST_PLACE = 0,
        WORK_PLACE = 1,
        SMOKING_PLACE = 2,
        LUNCH_PLACE = 3
    }

    public class Place : MonoBehaviour
    {
        [SerializeField] private PlaceTypes _placeType;

        public PlaceTypes PlaceType => _placeType;
    }
}