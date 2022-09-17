using System;
using System.Collections.Generic;
using System.Linq;
using Game.Common;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Game.Gameplay
{
    public class Tumba : IPositionOwner, IGameObjectOwner, ITickable
    {
        private readonly GameObject _gameObject;

        private readonly EnemyRegistry _enemyRegistry;
        private readonly Config _config;

        private IEnumerable<Enemy> _enemiesInRadius;

        private List<ISpell> _activeSpells = new List<ISpell>();

        private float _dueTimeDeactivation;

        public Tumba(GameObject gameObject, EnemyRegistry enemyRegistry, Config config)
        {
            _gameObject = gameObject;
            _enemyRegistry = enemyRegistry;
            _config = config;
        }

        public void Tick()
        {
            foreach (ISpell spell in _activeSpells) 
                spell.Tick();
            
            if (_dueTimeDeactivation <= Time.time)
                Deactivate();
        }

        public void Activate()
        {
            if (_dueTimeDeactivation > Time.time)
                return;

            _dueTimeDeactivation = Time.time + _config.LifeTime;
            IEnumerable<Enemy> enumerable = _enemyRegistry.Enemies.Where(InRadius);

            foreach (Enemy enemy in enumerable)
            {
                var pullSpell = new PullSpell(this);
                
                var spell = new DamageSpell(pullSpell,_config.Damage , _config.SpellRate);
                
                spell.Activate(enemy);
                
                _activeSpells.Add(spell);
            }
        }

        public void Deactivate()
        {
            foreach (ISpell spell in _activeSpells)
                spell.Deactivate();

            Object.Destroy(GameObject);
        }

        public Vector3 Position { get => GameObject.transform.position; set => GameObject.transform.position = value; }

        public GameObject GameObject => _gameObject;

        private bool InRadius(Enemy enemy) => enemy.DistanceTo(this) <= _config.Radius;

        [Serializable]
        public class Config
        {
            public float Radius = 50f;
            public float LifeTime = 5f;
            public int Damage = 15;
            public float SpellRate = 1f;
        }
    }
}