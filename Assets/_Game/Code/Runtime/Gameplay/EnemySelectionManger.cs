using Game.Common;
using Game.Gameplay.Components;
using UnityEngine;

namespace Game.Gameplay
{
    public class EnemySelectionManger : IInitializable
    {
        private readonly EnemyRegistry _enemyRegistry;

        public EnemySelectionManger(EnemyRegistry enemyRegistry)
        {
            _enemyRegistry = enemyRegistry;
        }

        public void Initialize()
        {
            
        }

        public void Select(GameObject gameObject)
        {
            
        }
    }
}