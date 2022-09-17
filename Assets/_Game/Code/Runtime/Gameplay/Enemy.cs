using System;
using Game.Common;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Game.Gameplay
{
    public class Enemy : ISelectable, IPositionOwner, IHealthable
    {
        private readonly IMovement _movement;
        private readonly int _startHealth;
        private readonly Transform _transform;
        
        public Enemy(IMovement movement, GameObject gameObject, int startHealth)
        {
            _movement = movement;
            _startHealth = startHealth;
            Health = startHealth;
            GameObject = gameObject;
            _transform = gameObject.transform;
        }

        public bool IsDead { get; private set; }

        public int Health { get; private set; }

        public event Action<IHealthable> HealthChanged;

        public Vector3 Position { get => GameObject.transform.position; set => GameObject.transform.position = value; }

        public event Action<ISelectable> Selected;

        public GameObject GameObject { get; }

        public void Select()
        {
            Debug.Log($"Enemy Selected {GetHashCode()}", GameObject);
            Selected?.Invoke(this);
        }

        public event Action<IHealthable> Dead;

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

        public void TakeDamage(int damage)
        {
            if (damage < 0)
                throw new ArgumentException($"{nameof(damage)} cannot be less then 0");

            if (IsDead)
                throw new InvalidOperationException($"Cant {nameof(TakeDamage)} when target Dead");

            Health -= damage;

            Health = Mathf.Clamp(Health, 0, _startHealth);

            HealthChanged?.Invoke(this);

            if (Health == 0)
                Die();
        }

        public void TakeHeal(int health)
        {
            if (health < 0)
                throw new ArgumentException($"{nameof(health)} cannot be less then 0");
            
            if (IsDead)
                throw new InvalidOperationException($"Cant {nameof(TakeHeal)} when target Dead");

            Health += health;

            Health = Mathf.Clamp(Health, 0, _startHealth);
            HealthChanged?.Invoke(this);
        }

        private void Die()
        {
            IsDead = true;
            Dead?.Invoke(this);
            Object.Destroy(GameObject);
        }
    }
}