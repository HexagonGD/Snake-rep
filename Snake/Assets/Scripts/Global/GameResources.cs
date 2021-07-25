using Snake.Factories;
using System.Collections.Generic;
using UnityEngine;

namespace Snake.Global
{
    [CreateAssetMenu(menuName = "Snake/GameResources")]
    public class GameResources : ScriptableObject
    {
        [SerializeField] private Factory _factory;
        [SerializeField] private List<Color> _colors;
        [SerializeField] private Material _mainMaterial;
        [SerializeField] private Material _secondMaterial;

        public Factory Factory => _factory;
        public IReadOnlyList<Color> Colors => _colors;
        public Material MainMaterial => _mainMaterial;
        public Material SecondMaterial => _secondMaterial;
    }
}