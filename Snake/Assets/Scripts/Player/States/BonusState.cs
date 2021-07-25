using Snake.Global;
using UnityEngine;

namespace Snake.Players.States
{
    public class BonusState : ISnakeState
    {
        private const float _bonusTime = 4f;

        private readonly Head _head;
        private readonly Transform _transform;

        private float _time;

        public BonusState(Head head)
        {
            _head = head;
            _transform = head.transform;
        }

        public void Begin()
        {
            Time.timeScale = 3f;
        }

        public void End() { }

        public void OnCollectCrystal() => _head.Eat();

        public void OnCollectMan(Color color) => _head.Eat();

        public void OnCollectMina() => _head.Eat();

        public void OnMove(float x) { }

        public void OnUpdate()
        {
            _time += Time.deltaTime / Time.timeScale;
            if(_time >= _bonusTime)
            {
                _head.SetState(new RunState(_head));
            }

            var position = _transform.position;
            position.x = position.x > 0 ?
                Mathf.Max(0, position.x - GlobalParams.SnakeSideSpeed * Time.deltaTime) :
                Mathf.Min(0, position.x + GlobalParams.SnakeSideSpeed * Time.deltaTime);
            position.z += GlobalParams.SnakeSpeed * Time.deltaTime;
            _transform.position = position;
        }
    }
}