using UnityEngine;

namespace Game.Gameplay
{
    public class KeyboardInput : IInput
    {
        private const string VERTICAL = "Vertical";
        private const string HORIZONTAL = "Horizontal";
        public Vector2 Move => new Vector2(Input.GetAxis(HORIZONTAL), Input.GetAxis(VERTICAL));
    }
}