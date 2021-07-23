using System;
using UnityEngine;
using Snake.Collections;
using Snake.Global;

namespace Snake.Maps
{
    public class Mapper
    {
        private Factory _factory;
        private LimitedQueue _locations;

        private float _time;
        private float _lengthLocation;
        private int _countCreateLocations;

        public Mapper(Action callback, int maxLocation)
        {
            _factory = General.Instance.GameResources.Factory;
            _locations = new LimitedQueue(maxLocation);
            callback += OnUpdate;
        }

        private void OnUpdate()
        {
            _time += Time.deltaTime;
            if (_time >= _lengthLocation)
            {
                _time -= _lengthLocation;
                CreateLocation();
            }
        }

        private void CreateLocation()
        {
            _countCreateLocations++;
            var location = _factory.CreateRandom();
            location.transform.position = Vector3.forward * _countCreateLocations;
            _locations.Enqueue(location);
        }
    }
}