using UI;
using UnityEngine;

namespace Game
{
    public class CubeSpawner : MonoBehaviour
    {
        [SerializeField] private SpawnDelayInput _spawnDelayInput;

        [SerializeField] private GameObject _cubePrefab;
        [SerializeField] private Vector3 _spawnPosition;

        private float _spawnDelay;
        private float _tickTimer;

        private void OnEnable()
        {
            _spawnDelayInput.OnSpawnDelayChanged += SetSpawnDelay;
        }

        private void OnDisable()
        {
            _spawnDelayInput.OnSpawnDelayChanged -= SetSpawnDelay;
        }

        private void Start()
        {
            _tickTimer = _spawnDelay;
        }

        private void Update()
        {
            _tickTimer -= Time.deltaTime;
            if (_tickTimer < 0)
            {
                Spawn();
            }
        }

        private void Spawn()
        {
            Instantiate(_cubePrefab, _spawnPosition, Quaternion.identity);
            _tickTimer = _spawnDelay;
        }

        private void SetSpawnDelay(float spawnDelay)
        {
            _spawnDelay = spawnDelay;
        }
    }
}
