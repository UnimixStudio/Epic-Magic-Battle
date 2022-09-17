using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game.Gameplay
{
    public class EnemySpawner : IInitializable
    {
        private readonly EnemySpawnData _spawnData;
        private readonly EnemyRegistry _registry;
        public EnemySpawner(EnemySpawnData spawnData, EnemyRegistry registry)
        {
            _spawnData = spawnData;
            _registry = registry;
        }

        public void Initialize() => SpawnEnemies();

        private void SpawnEnemies()
        {
            EnemyData[] types = _spawnData.Types;
            
            Dictionary<EnemyData, EnemyFactory> enemyFactories = types.ToDictionary(data => data, SelectEnemyFactory);

            for (int i = 0; i < _spawnData.Count; i++)
            {
                int range = Random.Range(0, types.Length);
                
                EnemyData enemyType = types[range];
                
                Enemy enemy = enemyFactories[enemyType].Create();
                
                _registry.Add(enemy);
            }
        }
        private EnemyFactory SelectEnemyFactory(EnemyData data) => 
            new EnemyFactory(_spawnData.Prefab, data, _spawnData.FieldSize);
    }
}