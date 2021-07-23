using Snake.Maps;
using System;
using UnityEngine;

namespace Snake.Managers
{
    public class Starter : MonoBehaviour
    {
        private event Action OnUpdate;

        void Start()
        {
            StartGame();
        }

        void Update()
        {
            OnUpdate.Invoke();
        }

        public void StartGame()
        {
            OnUpdate = null;
            var mapper = new Mapper(OnUpdate, 5);
        }
    }
}