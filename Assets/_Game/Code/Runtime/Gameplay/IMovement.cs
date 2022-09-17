using UnityEngine;

namespace Game.Gameplay
{
    public interface IMovement
    {
        void Move(Vector3 worldDirection);
    }
}