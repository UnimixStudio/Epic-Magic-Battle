namespace Game.Gameplay
{
    public interface ISpell : ITickable
    {
        void Activate(ISelectable target);
        void Deactivate();
    }
}