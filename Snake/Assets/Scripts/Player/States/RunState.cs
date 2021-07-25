using Snake.Global;
using UnityEngine;

namespace Snake.Players.States
{
    public class RunState : ISnakeState
    {
        private const int CountCrystalForBonus = 3;
        private const float MinX = -3f;
        private const float MaxX = 3f;

        private readonly Head _head;
        private readonly Transform _transform;

        private int _countCollectCrystal;
        private float _positionX = 0;

        public RunState(Head head)
        {
            _head = head;
            _transform = head.transform;
        }

        public void Begin() => Time.timeScale = 1f;

        public void End() { }

        public void OnCollectCrystal()
        {
            _countCollectCrystal++;
            if (_countCollectCrystal >= CountCrystalForBonus)
            {
                _head.SetState(new BonusState(_head));
            }
        }

        public void OnCollectMan(Color color)
        {
            if (_head.MainColor != color)
                _head.Dead();
            else
                _head.Eat();
        }

        public void OnCollectMina() => _head.Dead();

        public void OnMove(float x)
        {
            _positionX = Mathf.Clamp(x, MinX, MaxX);
        }

        public void OnUpdate()
        {
            var position = _transform.position;
            position.x = position.x > _positionX ?
                Mathf.Max(_positionX, position.x - GlobalParams.SnakeSideSpeed * Time.deltaTime) :
                Mathf.Min(_positionX, position.x + GlobalParams.SnakeSideSpeed * Time.deltaTime);
            position.z += GlobalParams.SnakeSpeed * Time.deltaTime;
            _transform.position = position;
        }
    }
}