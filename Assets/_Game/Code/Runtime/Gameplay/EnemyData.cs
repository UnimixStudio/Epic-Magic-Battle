using UnityEngine;

namespace Game.Gameplay
{
    [CreateAssetMenu(menuName = "Game/Data/Enemy", fileName = "EnemyData")]
    public class EnemyData : ScriptableObject
    {
        public float MovementSpeed = 10f;
        public Color Color = Color.magenta;
        public int Health = 100;
        public Vector3 Scale = Vector3.one;
    }
}