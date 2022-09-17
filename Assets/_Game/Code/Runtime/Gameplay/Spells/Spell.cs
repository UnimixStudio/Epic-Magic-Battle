using Game.Common;

namespace Game.Gameplay
{
    public abstract class Spell: ISpell
    {
        protected readonly IGameObjectOwner _owner;
        protected Enemy _target;

        protected Spell(IGameObjectOwner owner) => _owner = owner;
        public void Activate(ISelectable target) => _target = target as Enemy;

        public void Deactivate() => _target = null;
        
        public void Tick() => 
            ActionWithTarget();

        protected abstract void ActionWithTarget();
    }
}