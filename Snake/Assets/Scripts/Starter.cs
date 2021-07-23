using Snake.Maps;
using System;
using UnityEngine;

namespace Snake.Managers
{
    public class Starter : MonoBehaviour
    {
        private event Action OnUpdate;

        private Mapper _mapper;
        private Player _player;

        void Start()
        {
            StartGame();
        }

        void Update()
        {
            OnUpdate?.Invoke();
        }

        public void StartGame()
        {
            OnUpdate = null;
            _mapper = new Mapper(ref OnUpdate, 5);
            _player = new Player(ref OnUpdate);
        }
    }
}