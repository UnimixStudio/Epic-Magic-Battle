using UnityEngine;

namespace Game.Gameplay
{
    public class TransformMovement : IMovement
    {
        private readonly Transform _transform;
        private readonly float _speedMovement;

        public TransformMovement(Transform transform, float speedMovement)
        {
            _transform = transform;
            _speedMovement = speedMovement;
        }

        public void Move(Vector3 worldDirection) => 
            _transform.position += worldDirection.normalized * _speedMovement * Time.deltaTime;
    }
}