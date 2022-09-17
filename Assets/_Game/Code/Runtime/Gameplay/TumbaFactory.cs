using UnityEngine;

namespace Game.Gameplay
{
    public class TumbaFactory : ITickable
    {
        private readonly GameObject _prefab;
        private readonly EnemyRegistry _enemyRegistry;
        private GameObject _instance;
        private Tumba _currentTumba;

        public TumbaFactory(GameObject prefab, EnemyRegistry enemyRegistry)
        {
            _prefab = prefab;
            _enemyRegistry = enemyRegistry;
        }

        public Tumba Create()
        {
            _instance = Object.Instantiate(_prefab);
            _currentTumba = new Tumba(_instance, _enemyRegistry);
            return _currentTumba;
        }

        public void Tick() => _currentTumba?.Tick();
    }
}