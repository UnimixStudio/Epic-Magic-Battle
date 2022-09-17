using UnityEngine;

namespace Game.Common
{
    public interface IGameObjectOwner
    {
        GameObject GameObject { get; }
    }

    public static class GameObjectContainerExtensions
    {
        public static bool IsMe(this IGameObjectOwner owner, GameObject other) =>
            owner.GameObject.Equals(other);
    }
}