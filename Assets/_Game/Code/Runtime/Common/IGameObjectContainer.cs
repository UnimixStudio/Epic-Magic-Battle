using UnityEngine;

namespace Game.Common
{
    public interface IGameObjectContainer
    {
        GameObject GameObject { get; }
    }

    public static class GameObjectContainerExtensions
    {
        public static bool IsMe(this IGameObjectContainer container, GameObject other) =>
            container.GameObject.Equals(other);
    }
}