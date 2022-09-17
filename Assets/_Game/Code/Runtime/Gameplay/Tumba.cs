using System.Collections.Generic;
using System.Linq;
using Game.Common;
using UnityEngine;

namespace Game.Gameplay
{
    public class Tumba : IPositionOwner, IGameObjectOwner, ITickable
    {
        private readonly GameObject _gameObject;
        private readonly EnemyRegistry _enemyRegistry;

        private float Radius = 50f;
        private float lifetTime = 5f;
        private IEnumerable<Enemy> _enemiesInRadius;
        private List<ISpell> _activeSpells = new List<ISpell>();
        private float _dueTimeDeactivation;

        public Tumba(GameObject gameObject, EnemyRegistry enemyRegistry)
        {
            _gameObject = gameObject;
            _enemyRegistry = enemyRegistry;
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

            _dueTimeDeactivation = Time.time + lifetTime;
            IEnumerable<Enemy> enumerable = _enemyRegistry.Enemies.Where(InRadius);

            foreach (Enemy enemy in enumerable)
            {
                var pullSpell = new PullSpell(this);
                
                var spell = new DamageSpell(pullSpell, 15, 10);
                
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

        private bool InRadius(Enemy enemy) => enemy.DistanceTo(this) <= Radius;
    }
}