using Game.Gameplay;
using UnityEngine;

namespace Game.Common
{
    public static class PositionOwnerExtensions
    {
        public static float DistanceTo(this IPositionOwner owner, IPositionOwner other) =>
            Vector3.Distance(owner.Position,other.Position);
    }
}