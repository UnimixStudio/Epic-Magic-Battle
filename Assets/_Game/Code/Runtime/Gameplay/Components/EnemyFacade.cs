using UnityEngine;
using UnityEngine.EventSystems;

namespace Game.Gameplay.Components
{
    public class EnemyFacade : MonoBehaviour, IPointerDownHandler
    {
        private EnemySelectionManger _enemySelectionManger;
        private Enemy _enemy;

        public void Construct(Enemy enemy)
        {
            _enemy = enemy;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            _enemy.Select();
        }

        public void IntializeView()
        {
            
        }
    }
}