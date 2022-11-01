using System;
using DG.Tweening;
using UI;
using UnityEngine;

namespace Game
{
    public class CubeMovement : MonoBehaviour
    {
        [SerializeField] private SpeedInput _speedInput;
        [SerializeField] private DistanceInput _distanceInput;
        [SerializeField] private float _moveDelay;

        private Tween _tween;
        private float _speed;
        private float _distance;

        public event Action OnDeath;

        private void Awake()
        {
            _speedInput = FindObjectOfType<SpeedInput>();
            _distanceInput = FindObjectOfType<DistanceInput>();
        }

        private void Start()
        {
            _speed = _speedInput.Speed;
            _distance = _distanceInput.Distance;
            Play();
        }

        private void Play()
        {
            _tween?.Kill();
            float duration;
            if (_speed <= 0)
            {
                duration = 0;
            }
            else
            {
                duration = _distance / _speed;
            }

            Sequence sequence = DOTween.Sequence();
            sequence.AppendInterval(_moveDelay);
            sequence.Append(transform
                .DOMove(GetDirection(), duration));
            sequence.OnComplete(() => OnDeath?.Invoke());

            _tween = sequence;
        }

        private Vector3 GetDirection()
        {
            return Vector3.right * _distance;
        }

        private void SetDistance(float distance)
        {
            _distance = distance;
        }

        private void SetSpeed(float speed)
        {
            _speed = speed;
        }
    }
}