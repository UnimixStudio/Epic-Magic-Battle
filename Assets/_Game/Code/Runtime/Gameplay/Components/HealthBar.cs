using UnityEngine;
using UnityEngine.UI;

namespace Game.Gameplay.Components
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private Image _fill;
        private int _startValue;

        public void Bind(IHealthable healthable, int startValue)
        {
            _startValue = startValue;
            healthable.HealthChanged += HealthableOnHealthChanged;
        }

        private void HealthableOnHealthChanged(IHealthable healthable)
        {
            Debug.Log(nameof(HealthableOnHealthChanged));
            float health = healthable.Health;
            Debug.Log("health = " + health);
            _fill.fillAmount = health / _startValue;
        }
    }
}