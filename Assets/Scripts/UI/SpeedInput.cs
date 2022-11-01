using TMPro;
using UnityEngine;

namespace UI
{
    public class SpeedInput : MonoBehaviour
    {
        [SerializeField] private TMP_InputField _speedInputField;
        
        public float Speed { get; private set; }

        private void Awake()
        {
            _speedInputField.onValueChanged.AddListener(SetSpeed);
        }

        private void Start()
        {
            SetSpeed("5");
        }

        private void SetSpeed(string speedValue)
        {
            if (speedValue == null)
                return;
            
            float.TryParse(speedValue, out float speed);

            if (speed <= 0)
                return;

            Speed = speed;
        }
    }
}
