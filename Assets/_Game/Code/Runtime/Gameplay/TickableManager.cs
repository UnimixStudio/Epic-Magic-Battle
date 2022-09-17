using System.Collections.Generic;
using System.Linq;

namespace Game.Gameplay
{
    public class TickableManager
    {
        private readonly List<ITickable> _tickables;

        public TickableManager(params ITickable[] tickables) => 
            _tickables = tickables.ToList();

        public void Tick()
        {
            for (int i = _tickables.Count - 1; i >= 0; i--) 
                _tickables[i].Tick();
        }

        public void RegisterTickable(ITickable tickable) => 
            _tickables.Add(tickable);
        
        public void UnregisterTickable(ITickable tickable) => 
            _tickables.Remove(tickable);
    }
}