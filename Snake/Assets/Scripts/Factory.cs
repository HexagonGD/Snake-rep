using Snake.Maps;
using System.Collections.Generic;
using UnityEngine;

namespace Snake.Factories
{
    [CreateAssetMenu(menuName = "Snake/Factory", fileName = "Factory")]
    public class Factory : ScriptableObject
    {
        [SerializeField] private List<Location> _locationPrefabs;

        public Location Create(int index)
        {
            return Instantiate(_locationPrefabs[index]);
        }

        public Location CreateRandom()
        {
            return Create(Random.Range(0, _locationPrefabs.Count));
        }
    }
}