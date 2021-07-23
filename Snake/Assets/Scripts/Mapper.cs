using System;
using UnityEngine;
using Snake.Collections;
using Snake.Global;
using Snake.Factories;

namespace Snake.Maps
{
    public class Mapper
    {
        private Factory _factory;
        private LimitedQueue _locations;

        private float _time = 10f;
        private float _lengthLocation = 20f;
        private int _countCreateLocations;

        public Mapper(ref Action callback, int maxLocation)
        {
            _factory = General.Instance.GameResources.Factory;
            _locations = new LimitedQueue(maxLocation);
            callback += OnUpdate;
        }

        private void OnUpdate()
        {
            _time += Time.deltaTime;
            if (_time >= _lengthLocation / GlobalParams.SnakeSpeed)
            {
                _time -= _lengthLocation / GlobalParams.SnakeSpeed;
                CreateLocation();
            }
        }

        private void CreateLocation()
        {
            _countCreateLocations++;
            var location = _factory.CreateRandom();
            location.transform.position = Vector3.forward * _countCreateLocations * _lengthLocation;
            _locations.Enqueue(location);
        }
    }
}