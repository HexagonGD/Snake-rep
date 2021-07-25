using Snake.Maps;
using UnityEngine;

namespace Snake.Factories
{
    [CreateAssetMenu(menuName = "Snake/Factory", fileName = "Factory")]
    public class Factory : ScriptableObject
    {
        [SerializeField] private MapConfig _locationPrefabs;

        public int CountLocations => _locationPrefabs.Locations.Count;

        public Location Create(int index)
        {
            return Instantiate(_locationPrefabs.Locations[index++]);
        }

        public Location CreateRandom()
        {
            return Create(Random.Range(0, _locationPrefabs.Locations.Count));
        }
    }
}