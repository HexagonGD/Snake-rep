using Snake.Factories;
using UnityEngine;

namespace Snake.Global
{
    [CreateAssetMenu(menuName = "Snake/GameResources")]
    public class GameResources : ScriptableObject
    {
        [SerializeField] private Factory _factory;

        public Factory Factory => _factory;
    }
}