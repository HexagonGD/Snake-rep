using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Snake.Players
{
    public class Player
    {
        private Head _head;

        public Player(ref Action callback)
        {
            _head = Object.FindObjectOfType<Head>();
            callback += OnUpdate;
        }

        private void OnUpdate()
        {
            var position = Input.mousePosition;
            position.z = 15f;
            _head.Move(Camera.main.ScreenToWorldPoint(position).x);
        }
    }
}