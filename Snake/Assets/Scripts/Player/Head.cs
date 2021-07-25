using Snake.Foods;
using Snake.Global;
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
        [SerializeField] private Renderer _renderer;
        [SerializeField] private Material _mainColor;
        [SerializeField] private Material _secondColor;

        private float _speed;
        private float _positionX;
        [SerializeField] private int _maxSegments = 20;
        [SerializeField] private int _startSegments = 3;
        private int _countCollectCrystal;

        public Color MainColor => _mainColor.color;

        private void Start()
        {
            _transform = transform;
            _speed = GlobalParams.SnakeSpeed;
            _bodies.Add(transform);
            for (var i = 0; i < _startSegments; i++) Eat();
        }

        private void Update()
        {
            var position = _transform.position;
            position.x = position.x > _positionX ?
                Mathf.Max(_positionX, position.x - _speed * Time.deltaTime) :
                Mathf.Min(_positionX, position.x + _speed * Time.deltaTime);
            position.z += _speed * Time.deltaTime;
            _transform.position = position;

            for (var i = 1; i < _bodies.Count; i++)
            {
                position = _bodies[i].position;
                position.z += _speed * Time.deltaTime;
                position.x = Mathf.Lerp(position.x, _bodies[i - 1].position.x, Time.deltaTime * 20f);
                _bodies[i].position = position;
            }
        }

        public void Move(float x)
        {
            _positionX = x;
        }

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

        public void CollectCrystal()
        {
            _countCollectCrystal++;
        }

        public void Dead()
        {
            SceneManager.LoadScene("Game");
        }

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