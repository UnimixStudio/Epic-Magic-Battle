namespace Game.Gameplay
{
    public class InitializableManager
    {
        private readonly IInitializable[] _initializables;

        public InitializableManager(params  IInitializable[] initializables) => 
            _initializables = initializables;

        public void Initailize()
        {
            foreach (IInitializable initializable in _initializables) 
                initializable.Initialize();
        }
    }
}