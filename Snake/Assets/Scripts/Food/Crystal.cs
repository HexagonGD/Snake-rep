using Snake.Players;
using UnityEngine;

namespace Snake.Foods
{
    public class Crystal : MonoBehaviour, ICollect
    {
        public void Collect(Head head)
        {
            head.CollectCrystal();
            Destroy(gameObject);
        }
    }
}