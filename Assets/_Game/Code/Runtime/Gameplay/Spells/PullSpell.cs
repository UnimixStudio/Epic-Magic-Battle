using Game.Common;

namespace Game.Gameplay
{
    public class PullSpell : Spell
    {
        public PullSpell(IGameObjectOwner owner) : base(owner) { }

        protected override void ActionWithTarget() => 
            _target?.Pull(_owner.GameObject.transform);
    }
}