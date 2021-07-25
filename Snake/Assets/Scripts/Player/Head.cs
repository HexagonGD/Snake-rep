using Snake.Foods;
using Snake.Global;
using Snake.Players.States;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Snake.Players
{
    public class Head : MonoBehaviour
    {
        [SerializeField] private GameObject _bodyPrefab;
        private List<Transform> _bodies = new List<Transform>();
        private Transform _transform;
        private ISnakeState _state;

        [Header("Show")]
        [SerializeField] private Renderer _renderer;
        [SerializeField] private Material _mainColor;
        [SerializeField] private Material _secondColor;

        [Header("CountSegments")]
        [SerializeField] private int _maxSegments;
        [SerializeField] private int _startSegments;

        public Color MainColor => _mainColor.color;

        private void Start()
        {
            SetState(new RunState(this));
            _transform = transform;
            _bodies.Add(transform);
            for (var i = 0; i < _startSegments; i++) Eat();
        }

        private void Update()
        {
            _state.OnUpdate();

            Vector3 position;
            for (var i = 1; i < _bodies.Count; i++)
            {
                position = _bodies[i].position;
                position.z += GlobalParams.SnakeSpeed * Time.deltaTime;
                position.x = Mathf.Lerp(position.x, _bodies[i - 1].position.x, Time.deltaTime * 25f);
                _bodies[i].position = position;
            }
        }

        public void SetState(ISnakeState state)
        {
            _state?.End();
            _state = state;
            _state.Begin();
        }

        public void Move(float x) => _state.OnMove(x);

        public void Eat()
        {
            if (_bodies.Count > _maxSegments) return;
            var position = _bodies[_bodies.Count - 1].position;
            var body = Instantiate(_bodyPrefab, position, Quaternion.identity);
            body.GetComponent<Renderer>().material = _bodies.Count % 2 == 0 ? _mainColor : _secondColor;
            _bodies.Add(body.transform);
            RefreshScale();
            RefreshPosition();
        }

        public void CollectCrystal() => _state.OnCollectCrystal();

        public void CollectMina() => _state.OnCollectMina();

        public void CollectMan(Color color) => _state.OnCollectMan(color);

        public void Dead() => SceneManager.LoadScene("Game");

        public void ChangeMainColor(Color color)
        {
            _mainColor.color = color;
        }

        public void ChangeSecondColor(Color color)
        {
            _secondColor.color = color;
        }

        private void RefreshScale()
        {
            for (var i = 0; i < _bodies.Count; i++)
            {
                _bodies[i].localScale = Vector3.one / _maxSegments * Mathf.Min(_maxSegments, _bodies.Count - i);
            }
        }

        private void RefreshPosition()
        {
            Vector3 position;
            for (var i = 1; i < _bodies.Count; i++)
            {
                position = _bodies[i].position;
                position.z = _bodies[i - 1].position.z - _bodies[i - 1].localScale.z / 4f;
                _bodies[i].position = position;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            var collect = other.GetComponent<ICollect>();
            collect?.Collect(this);
        }
    }
}