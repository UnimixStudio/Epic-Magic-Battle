using UnityEngine;

namespace Game.Gameplay
{
    public abstract class HealthableSpell : ISpell
    {
        private readonly ISpell _subSpell;
        private readonly float _spellRate;
        private IHealthable _healthable;
        private float nextSpellCast;
        public HealthableSpell(ISpell subSpell,  float spellRate)
        {
            _subSpell = subSpell;
            _spellRate = spellRate;
        }

        public void Tick()
        {
            if (_healthable == null)
                return;
            
            _subSpell?.Tick();

            if (nextSpellCast > Time.time) 
                return;

            nextSpellCast = Time.time + _spellRate;
            
            ChangeHealthable(_healthable);
        }

        protected abstract void ChangeHealthable(IHealthable healthable);

        public void Activate(ISelectable target)
        {
            _healthable = target as IHealthable;
            _healthable.Dead += OnDeadTarget; 
            _subSpell.Activate(target);
        }

        private void OnDeadTarget(IHealthable healthable)
        {
            healthable.Dead -= OnDeadTarget;
            Deactivate();
        }

        public void Deactivate()
        {
            _healthable = null;
            _subSpell.Deactivate();
        }
    }
}