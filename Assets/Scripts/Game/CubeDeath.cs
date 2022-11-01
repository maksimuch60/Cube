using UnityEngine;

namespace Game
{
    public class CubeDeath : MonoBehaviour
    {
        [SerializeField] private CubeMovement _cubeMovement;

        private void OnEnable()
        {
            _cubeMovement.OnDeath += Destroy;
        }

        private void OnDisable()
        {
            _cubeMovement.OnDeath -= Destroy;
        }

        private void Destroy()
        {
            Destroy(gameObject);
        }
    }
}