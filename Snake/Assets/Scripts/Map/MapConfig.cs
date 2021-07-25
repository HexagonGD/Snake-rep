using System.Collections.Generic;
using UnityEngine;

namespace Snake.Maps
{
    [CreateAssetMenu(fileName = "MapConfig", menuName = "Snake/MapConfig")]
    public class MapConfig : ScriptableObject
    {
        [SerializeField] private List<Location> _locations;

        public IReadOnlyList<Location> Locations => _locations;
    }
}