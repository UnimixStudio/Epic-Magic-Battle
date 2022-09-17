using System;
using Game.Common;

namespace Game.Gameplay
{
    public interface ISelectable : IGameObjectOwner
    {
        event Action<ISelectable> Selected;
        void Select();
    }
}