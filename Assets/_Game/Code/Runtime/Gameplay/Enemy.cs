using System;
using UnityEngine;

namespace Game.Gameplay
{
    public class Enemy : ISelectable
    {
        private readonly IMovement _movement;
        private readonly Transform _transform;

        public Enemy(IMovement movement, GameObject gameObject)
        {
            _movement = movement;
            GameObject = gameObject;
            _transform = gameObject.transform;
        }

        public event Action<ISelectable> Selected;
        
        public GameObject GameObject { get; }

        public void Select()
        {
            Debug.Log($"Enemy Selected {GetHashCode()}", GameObject);
            Selected?.Invoke(this);
        }

        public void Push(Transform from)
        {
            Vector3 direction = _transform.position - from.position;
            direction.y = 0f;
            _movement.Move(direction);
        }

        public void Pull(Transform from)
        {
            Vector3 direction = from.position - _transform.position;
            direction.y = 0f;
            _movement.Move(direction);
        }
    }
}