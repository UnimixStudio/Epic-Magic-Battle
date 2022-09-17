using Game.Common;

namespace Game.Gameplay
{
    public class PushSpell : Spell
    {
        public PushSpell(IGameObjectOwner owner) : base(owner) { }
        protected override void ActionWithTarget() => 
            _target?.Push(_owner.GameObject.transform);
    }
}