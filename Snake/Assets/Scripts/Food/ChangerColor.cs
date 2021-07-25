using Snake.Players;
using UnityEngine;

namespace Snake.Foods
{
    [RequireComponent(typeof(Renderer))]
    public class ChangerColor : MonoBehaviour, ICollect
    {
        public void Collect(Head head)
        {
            var renderer = GetComponent<Renderer>();
            head.ChangeMainColor(renderer.material.color);
        }
    }
}