using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Game.Gameplay.Components
{
    public class EnemyFacade : MonoBehaviour, IPointerDownHandler
    {
        [SerializeField] private Renderer _renderer;
        [SerializeField] private HealthBar _healthBar;

        private EnemySelectionManger _enemySelectionManger;
        private Enemy _enemy;
        private EnemyData _data;
        private float _jumpDistance;

        public void Construct(Enemy enemy) => _enemy = enemy;

        public void InitializeView(EnemyData data)
        {
            _data = data;
            _renderer.material.color = data.Color;
            transform.localScale = data.Scale;
            _healthBar.Bind(_enemy, data.Health);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.TryGetComponent(out EnemyFacade enemy))
                enemy.Explode(transform);
        }

        private void Explode(Transform from)
        {
            _enemy.TakeDamage((int)(_data.Health * 0.5f));
            
            if (_enemy.IsDead)
                return;

            Vector3 direction = from.position - transform.position;
            direction.y = _data.Scale.y * 0.5f;
            direction.Normalize();

            _jumpDistance = 10f;

            Vector3 endValue = transform.position + direction * _jumpDistance;
            
            transform.DOJump(endValue, 10, 1, 1f);
        }

        public void OnPointerDown(PointerEventData eventData) => _enemy.Select();
    }
}