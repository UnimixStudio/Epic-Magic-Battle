using System;
using System.Collections.Generic;

namespace Game.Gameplay
{
    public class EnemyRegistry
    {
        private readonly List<Enemy> _enemies = new List<Enemy>();
        public IReadOnlyList<Enemy> Enemies => _enemies;

        public void Add(Enemy enemy)
        {
            if (_enemies.Contains(enemy))
                throw new ArgumentException("Enemy contains in Registry");
            
            _enemies.Add(enemy);
        }

        public void Remove(Enemy enemy)
        {
            if (_enemies.Contains(enemy) == false)
                throw new ArgumentException("Enemy Not contains in Registry");
            
            _enemies.Remove(enemy);
        }
    }
}