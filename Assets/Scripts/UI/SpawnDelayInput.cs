using System;
using TMPro;
using UnityEngine;

namespace UI
{
    public class SpawnDelayInput : MonoBehaviour
    {
        [SerializeField] private TMP_InputField _spawnDelayInputField;
        
        public event Action<float> OnSpawnDelayChanged;

        private void Awake()
        {
            _spawnDelayInputField.onValueChanged.AddListener(SetSpawnDelay);
        }

        private void Start()
        {
            SetSpawnDelay("1");
        }

        private void SetSpawnDelay(string spawnDelayValue)
        {
            if (spawnDelayValue == null)
                return;
            
            float.TryParse(spawnDelayValue, out float spawnDelay);
            
            if (spawnDelay <= 0)
                return;

            OnSpawnDelayChanged?.Invoke(spawnDelay);
        }
    }
}
