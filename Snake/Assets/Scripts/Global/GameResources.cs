using Snake.Factories;
using Snake.Maps;
using System.Collections.Generic;
using UnityEngine;

namespace Snake.Global
{
    [CreateAssetMenu(menuName = "Snake/GameResources")]
    public class GameResources : ScriptableObject
    {
        [SerializeField] private Factory _factory;
        [SerializeField] private List<Color> _colors;
        [SerializeField] private MapConfig _mapConfig;

        public Factory Factory => _factory;
        public IReadOnlyList<Color> Colors => _colors;
    }
}