using System;
using UnityEngine;
using Snake.Collections;
using Snake.Global;
using Snake.Factories;
using System.Collections.Generic;
using Random = UnityEngine.Random;

namespace Snake.Maps
{
    public class Mapper
    {
        private Factory _factory;
        private LimitedQueue _locations;
        private IReadOnlyList<Color> _colors;

        private float _time = 10f;
        private float _lengthLocation = 20f;
        private int _countCreateLocations;

        public Mapper(ref Action callback, int maxLocation)
        {
            _factory = General.Instance.GameResources.Factory;
            _locations = new LimitedQueue(maxLocation);
            callback += OnUpdate;
            _colors = General.Instance.GameResources.Colors;
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
            if (_countCreateLocations < _factory.CountLocations)
            {
                var location = _factory.Create(_countCreateLocations++);
                location.transform.position = Vector3.forward * _countCreateLocations * _lengthLocation;
                SetColors(location);
                _locations.Enqueue(location);
            }
        }

        private void SetColors(Location location)
        {
            var indexColor = Random.Range(0, _colors.Count);
            location.SetColorFirstGroup(_colors[indexColor]);
            location.SetColorSecondGroup(_colors[++indexColor % _colors.Count]);
        }
    }
}