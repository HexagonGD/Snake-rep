using Snake.Players;
using UnityEngine;

namespace Snake.Foods
{
    public class Mina : MonoBehaviour, ICollect
    {
        public void Collect(Head head)
        {
            head.CollectMina();
            Destroy(gameObject);
        }
    }
}