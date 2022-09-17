using System.Collections.Generic;
using UnityEngine;

namespace Game.Gameplay
{
    using Common;
    public class GameplayCompositionRoot : MonoBehaviour
    {
        [SerializeField] private float _speedMovement = 10f;
        [SerializeField] private int _heal = 10;
        [SerializeField] private int _damage = 10;
        [SerializeField] private float _spellRate = 1f;
        [SerializeField] private GameObject _player;
        [SerializeField] private GameObject _tumbaPrefab;
        [SerializeField] private EnemySpawnData _enemySpawnData;

        private TickableManager _tickableManager;
        private InitializableManager _initializableManager;

        private void Awake()
        {
            var initializables = new List<IInitializable>();
            var tickables = new List<ITickable>();

            Player player = SetupPlayer(tickables);

            EnemyRegistry enemyRegistry = SetupEnemies(initializables);

            var selectionManger = new EnemySelectionManger(enemyRegistry);

            SpellManager spellManager = SetupsSpells(player, selectionManger, tickables, enemyRegistry);

            tickables.Add(spellManager);

            initializables.Add(selectionManger);

            _initializableManager = new InitializableManager(initializables.ToArray());

            _tickableManager = new TickableManager(tickables.ToArray());
        }

        private SpellManager SetupsSpells(
            IGameObjectOwner owner,
            EnemySelectionManger selectionManger,
            List<ITickable> tickables,
            EnemyRegistry enemyRegistry)
        {
            var tumbaFactory = new TumbaFactory(_tumbaPrefab, enemyRegistry);
            
            tickables.Add(tumbaFactory);

            var pullSpell = new PullSpell(owner);
            var pushSpell = new PushSpell(owner);
            var damageSpell = new DamageSpell(pushSpell, _damage, _spellRate );
            var healSpell = new HealSpell(pullSpell, _heal, _spellRate );

            var tumbaSpell = new TumbaSpell(owner, tumbaFactory);
            
            var playerSpells = new ISpell[]
            {
                damageSpell, healSpell, tumbaSpell
            };

            var spellManager = new SpellManager(selectionManger, playerSpells);

            tickables.AddRange(playerSpells);
            
            return spellManager;
        }

        private Player SetupPlayer(ICollection<ITickable> tickables)
        {
            IMovement playerMovement = new TransformMovement(_player.transform, _speedMovement);
            IInput playerInput = new KeyboardInput();

            var player = new Player(playerMovement, playerInput, _player);

            tickables.Add(player);

            return player;
        }

        private EnemyRegistry SetupEnemies(ICollection<IInitializable> initializables)
        {
            var enemyRegistry = new EnemyRegistry();
            var enemySpawner = new EnemySpawner(_enemySpawnData, enemyRegistry);

            initializables.Add(enemySpawner);

            return enemyRegistry;
        }

        private void Start() => _initializableManager.Initailize();

        private void Update() => _tickableManager.Tick();
    }
}