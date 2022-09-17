using UnityEngine;
using UnityEngine.EventSystems;

namespace Game.Gameplay.Components
{
    public class EnemyFacade : MonoBehaviour, IPointerDownHandler
    {
        [SerializeField] private Renderer _renderer;
        
        private EnemySelectionManger _enemySelectionManger;
        private Enemy _enemy;

        public void Construct(Enemy enemy) => 
            _enemy = enemy;

        public void InitializeView(EnemyData data)
        {
            _renderer.material.color = data.Color;
            transform.localScale = data.Scale;
        }

        public void OnPointerDown(PointerEventData eventData) => 
            _enemy.Select();
    }
}