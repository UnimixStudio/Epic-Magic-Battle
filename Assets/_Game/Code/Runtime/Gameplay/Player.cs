using Game.Common;
using UnityEngine;

namespace Game.Gameplay
{
    public class Player : ITickable, IGameObjectOwner
    {
        private readonly IMovement _movement;
        private readonly IInput _input;

        public Player(IMovement movement, IInput input, GameObject  gameObject)
        {
            _movement = movement;
            _input = input;
            GameObject = gameObject;
        }

        public void Tick()
        {
            Vector2 inputMove = _input.Move;
            
            var worldDirection = new Vector3(inputMove.x,0,inputMove.y);
            
            _movement.Move(worldDirection);
        }

        public GameObject GameObject { get; }
    }
}