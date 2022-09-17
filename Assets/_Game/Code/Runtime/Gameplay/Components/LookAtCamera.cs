using UnityEngine;

namespace Game.Gameplay.Components
{
    public class LookAtCamera : MonoBehaviour
    {
        private Transform _mainTransform;

        private void Awake() => _mainTransform = Camera.main.transform;

        private void Update() => transform.LookAt(_mainTransform);
    }
}
