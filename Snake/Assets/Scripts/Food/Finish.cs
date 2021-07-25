using Snake.Players;
using UnityEngine;

namespace Snake.Foods
{
    public class Finish : MonoBehaviour, ICollect
    {
        public void Collect(Head head)
        {
            head.Dead();
        }
    }
}