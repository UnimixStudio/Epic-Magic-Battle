using UnityEngine;

namespace Game.Common
{
    public interface IGameObjectOwner
    {
        GameObject GameObject { get; }
    }
}