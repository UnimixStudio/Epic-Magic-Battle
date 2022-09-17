using System;

namespace Game.Gameplay
{
    public interface ISelectable
    {
        event Action<ISelectable> Selected;
        void Select();
    }
}