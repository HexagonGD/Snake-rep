using Snake.Players;
using UnityEngine;

namespace Snake.Foods
{
    public class People : MonoBehaviour, ICollect
    {
        [SerializeField] private Renderer _renderer;

        public void Collect(Head head)
        {
            head.CollectMan(_renderer.material.color);
            Destroy(gameObject);
        }

        [ContextMenu("RenameInFirstGroup")]
        private void RenameInFirstGroup()
        {
            gameObject.name = "Man - 1";
        }

        [ContextMenu("RenameInSecondGroup")]
        private void RenameInSecondGroup()
        {
            gameObject.name = "Man - 2";
        }
    }
}