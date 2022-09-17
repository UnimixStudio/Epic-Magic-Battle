namespace Game.Gameplay
{
    public class EnemySelectionManger : IInitializable
    {
        private readonly EnemyRegistry _enemyRegistry;
        private ISelectable _selectable;

        public EnemySelectionManger(EnemyRegistry enemyRegistry) => _enemyRegistry = enemyRegistry;

        public ISelectable Selectable => _selectable;

        public void Initialize()
        {
            foreach (Enemy enemy in _enemyRegistry.Enemies) 
                enemy.Selected += SelectEnemy;
        }

        private void SelectEnemy(ISelectable selectable)
        {
            _selectable = selectable;
        }
    }
}