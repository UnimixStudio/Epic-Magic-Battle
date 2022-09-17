using System.Collections.Generic;
using UnityEngine;

namespace Game.Gameplay
{
    public class GameplayCompositionRoot : MonoBehaviour
    {
        [SerializeField] private GameObject _player;
        [SerializeField] private float _speedMovement = 10f;
        [SerializeField] private EnemySpawnData _enemySpawnData;

        private TickableManager _tickableManager;

        private List<Enemy> _enemies = new List<Enemy>();
        private InitializableManager _initializableManager;

        private void Awake()
        {
            IMovement playerMovement = new TransformMovement(_player.transform, _speedMovement);
            IInput playerInput = new KeyboardInput();

            var player = new Player(playerMovement, playerInput);

            var enemyRegistry = new EnemyRegistry();
            var selectionManger = new EnemySelectionManger(enemyRegistry);
            var enemySpawner = new EnemySpawner(_enemySpawnData, enemyRegistry);

            var testManger = new PushPullTestManger(enemyRegistry, _player.transform);

            _initializableManager = new InitializableManager(enemySpawner);
            _tickableManager = new TickableManager(player, testManger);
        }

        private void Start() => _initializableManager.Initailize();

        private void Update() => _tickableManager.Tick();
    }
}