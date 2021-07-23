using UnityEngine;

namespace Snake.Global
{
    [CreateAssetMenu(menuName = "HitMaster/GameResources")]
    public class GameResources : ScriptableObject
    {
        [SerializeField] private Factory _factory;

        public Factory Factory => _factory;
    }
}