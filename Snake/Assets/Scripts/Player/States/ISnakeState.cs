using UnityEngine;

namespace Snake.Players.States
{
    public interface ISnakeState
    {
        void Begin();
        void End();
        void OnUpdate();
        void OnMove(float x);
        void OnCollectMina();
        void OnCollectCrystal();
        void OnCollectMan(Color color);
    }
}