namespace Game.Gameplay
{
    public class DamageSpell : HealthableSpell
    {
        private readonly int _damage;
        public DamageSpell(ISpell subSpell, int damage, float spellRate) 
            : base(subSpell,  spellRate) => 
            _damage = damage;

        protected override void ChangeHealthable(IHealthable healthable) => 
            healthable.TakeDamage(_damage);
    }
}