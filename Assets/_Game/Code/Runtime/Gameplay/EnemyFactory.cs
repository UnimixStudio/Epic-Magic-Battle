using Game.Gameplay.Components;
using UnityEngine;

namespace Game.Gameplay
{
    public class EnemyFactory
    {
        private readonly GameObject _prefab;
        private readonly EnemyData _data;
        private readonly Vector2 _fieldSize;
        private float _height;

        public EnemyFactory(GameObject prefab, EnemyData data, Vector2 fieldSize)
        {
            _prefab = prefab;
            _data = data;
            _fieldSize = fieldSize;
        }

        public Enemy Create()
        {
            GameObject instance = Object.Instantiate(_prefab, Position, Quaternion.identity);

            Transform transform = instance.transform;
            
            var facade = instance.GetComponent<EnemyFacade>();
            
            var enemy = new Enemy(new TransformMovement(transform, _data.MovementSpeed), instance, _data.Health);
            
            facade.Construct(enemy);
            facade.InitializeView(_data);

            return enemy;
        }

        private Vector3 Position
        {
            get
            {
                float x = GetRandomAxisPoint(_fieldSize.x);
                float y = _data.Scale.y * 0.5f;
                float z = GetRandomAxisPoint(_fieldSize.y);

                return new Vector3(x, y, z);
            }
        }

        private static float GetRandomAxisPoint(float size) => 
            Random.Range(-size * 0.5f, size * 0.5f);
    }
}