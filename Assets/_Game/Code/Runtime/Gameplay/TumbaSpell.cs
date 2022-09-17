using Game.Common;

namespace Game.Gameplay
{
    public class TumbaSpell : ISpell
    {
        private readonly IGameObjectOwner _owner;
        private readonly TumbaFactory _factory;
        private Tumba _tumba;

        public TumbaSpell(IGameObjectOwner owner, TumbaFactory factory)
        {
            _owner = owner;
            _factory = factory;
        }

        public void Tick()
        {
            
        }

        public void Activate(ISelectable target)
        {
            _tumba = _factory.Create();
            _tumba.GameObject.transform.position = _owner.GameObject.transform.position;
            _tumba.Activate();
        }

        public void Deactivate()
        {
            _tumba?.Deactivate();
        }
    }
}