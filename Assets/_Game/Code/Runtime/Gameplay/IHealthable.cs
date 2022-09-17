using System;

namespace Game.Gameplay
{
    public interface IHealthable
    {
        public int Health { get; }
        public event Action<IHealthable> HealthChanged;
        public event Action<IHealthable> Dead;
        void TakeDamage(int damage);
        void TakeHeal(int health);
    }
}