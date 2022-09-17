using UnityEngine;

namespace Game.Gameplay
{
    public class TumbaFactory : ITickable
    {
        private readonly GameObject _prefab;
        private readonly EnemyRegistry _enemyRegistry;
        private GameObject _instance;
        private Tumba _currentTumba;
        private Tumba.Config _config;

        public TumbaFactory(GameObject prefab, EnemyRegistry enemyRegistry,Tumba.Config config)
        {
            _prefab = prefab;
            _enemyRegistry = enemyRegistry;
            _config = config;
        }

        public Tumba Create()
        {
            _instance = Object.Instantiate(_prefab);
            _config = new Tumba.Config();
            _currentTumba = new Tumba(_instance, _enemyRegistry, _config);
            return _currentTumba;
        }

        public void Tick() => _currentTumba?.Tick();
    }
}