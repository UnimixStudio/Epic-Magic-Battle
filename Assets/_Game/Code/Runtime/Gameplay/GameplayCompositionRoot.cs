using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game.Gameplay
{
    public class GameplayCompositionRoot : MonoBehaviour
    {
        [SerializeField] private GameObject _player;
        [SerializeField] private float _speedMovement = 10f;
        [SerializeField] private EnemySpawnData _enemySpawnData;

        private TickableManager _tickableManager;
        private InitializableManager _initializableManager;

        private void Awake()
        {
            Player player = SetupPlayer();

            var tickables = new List<ITickable>();
            
            var enemyRegistry = new EnemyRegistry();
            var enemySpawner = new EnemySpawner(_enemySpawnData, enemyRegistry);
            
            var selectionManger = new EnemySelectionManger(enemyRegistry);
            
            var playerSpells = new ISpell[]
            {
                new PullSpell(player), 
                new PushSpell(player)
            };
            
            var spellManager = new SpellManager(selectionManger, playerSpells);
            
            tickables.Add(player);
            tickables.Add(spellManager);
            tickables.AddRange(playerSpells);
            
            _initializableManager = new InitializableManager(enemySpawner, selectionManger);

            _tickableManager = new TickableManager(tickables.ToArray());
        }

        private void Start() => _initializableManager.Initailize();

        private void Update() => _tickableManager.Tick();

        private Player SetupPlayer()
        {
            IMovement playerMovement = new TransformMovement(_player.transform, _speedMovement);
            IInput playerInput = new KeyboardInput();

            return new Player(playerMovement, playerInput, _player);
        }
    }
}