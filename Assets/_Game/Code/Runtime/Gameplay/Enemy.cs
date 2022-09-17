
using System;
using UnityEngine;

namespace Game.Gameplay
{
    using Common;
    public class Enemy : IGameObjectContainer, ISelectable
    {
        private readonly IMovement _movement;
        private readonly GameObject _gameObject;
        private readonly Transform _transform;
        public event Action<ISelectable> Selected;

        public Enemy(IMovement movement, GameObject gameObject)
        {
            _movement = movement;
            _gameObject = gameObject;
            _transform = gameObject.transform;
        }

        public GameObject GameObject => _gameObject;

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

        public void Select() => 
            Selected?.Invoke(this);
    }
}