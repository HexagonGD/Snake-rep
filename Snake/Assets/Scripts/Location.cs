using System.Collections.Generic;
using UnityEngine;

namespace Snake.Maps
{
    public class Location : MonoBehaviour
    {
        [SerializeField] private List<Renderer> _firstPeopleGroup;
        [SerializeField] private List<Renderer> _secondPeopleGroup;

        private void Start()
        {
            SetColorFirstGroup(Color.red);
            SetColorSecondGroup(Color.blue);
        }

        public void SetColorFirstGroup(Color color)
        {
            SetColorGroup(_firstPeopleGroup, color);
        }

        public void SetColorSecondGroup(Color color)
        {
            SetColorGroup(_secondPeopleGroup, color);
        }

        private void SetColorGroup(List<Renderer> group, Color color)
        {
            for(var i = 0; i < group.Count; i++)
                group[i].material.SetColor("_Color", color);
        }

        public void Destroy()
        {
            Destroy(gameObject);
        }
    }
}