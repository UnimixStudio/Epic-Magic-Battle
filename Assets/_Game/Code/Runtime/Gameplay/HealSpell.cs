namespace Game.Gameplay
{
    public class HealSpell : HealthableSpell
    {
        private readonly int _health;
        public HealSpell(ISpell subSpell, int health,float spellRate) 
            : base(subSpell, spellRate) => 
            _health = health;

        protected override void ChangeHealthable(IHealthable healthable) => 
            healthable.TakeHeal(_health);
    }
}