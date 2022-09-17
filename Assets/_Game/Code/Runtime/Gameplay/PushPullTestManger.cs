using UnityEngine;

namespace Game.Gameplay
{
    public class PushPullTestManger : ITickable
    {
        private readonly EnemyRegistry _enemyRegistry;
        private readonly Transform _player;

        public PushPullTestManger(EnemyRegistry enemyRegistry, Transform player)
        {
            _enemyRegistry = enemyRegistry;
            _player = player;
        }

        public void Tick()
        {
            if (Input.GetKey(KeyCode.Alpha1))
                foreach (Enemy enemy in _enemyRegistry.Enemies)
                    enemy.Pull(_player);

            if (Input.GetKey(KeyCode.Alpha2))
                foreach (Enemy enemy in _enemyRegistry.Enemies)
                    enemy.Push(_player);
        }
    }
}