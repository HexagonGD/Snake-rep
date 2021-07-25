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
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit))
                {
                    _head.Move(hit.point.x);
                }
            }
        }
    }
}