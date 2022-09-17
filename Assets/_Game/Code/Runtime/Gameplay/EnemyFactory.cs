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

            SetScale(transform);
            
            SetColor(instance);
            
            var facade = instance.GetComponent<EnemyFacade>();
            
            var enemy = new Enemy(new TransformMovement(transform, _data.MovementSpeed), instance);
            
            facade.Construct(enemy);
            facade.IntializeView();

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

        private void SetColor(GameObject enemy) => 
            enemy.GetComponent<Renderer>().material.color = _data.Color;

        private void SetScale(Transform transform) => 
            transform.localScale = _data.Scale;

        private static float GetRandomAxisPoint(float size) => 
            Random.Range(-size * 0.5f, size * 0.5f);
    }
}