using TMPro;
using UnityEngine;

namespace UI
{
    public class DistanceInput : MonoBehaviour
    {
        [SerializeField] private TMP_InputField _distanceInputField;

        public float Distance { get; private set; }

        private void Awake()
        {
            _distanceInputField.onValueChanged.AddListener(SetDistance);
        }

        private void Start()
        {
            SetDistance("15");
        }

        private void SetDistance(string distanceValue)
        {
            if (distanceValue == null)
                return;

            float.TryParse(distanceValue, out float distance);

            if(distance <= 0)
                return;
            
            Distance = distance;
        }
    }
}
