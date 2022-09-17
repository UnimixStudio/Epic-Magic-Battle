using UnityEngine;

namespace Game.Gameplay
{
    internal class SpellManager : ITickable
    {
        private readonly EnemySelectionManger _selectionManger;
        private readonly ISpell[] _spells;

        public SpellManager(EnemySelectionManger selectionManger, params ISpell[] spells)
        {
            _selectionManger = selectionManger;
            _spells = spells;
        }

        private void ActivateSpell(int spellIndex)
        {
            if(_selectionManger.Selectable == null)
                return;
            
            _spells[spellIndex].Activate(_selectionManger.Selectable);
        }
        private void DeactivateSpell(int spellIndex)
        {
            if(_selectionManger.Selectable == null)
                return;
            
            _spells[spellIndex].Deactivate();
        }

        public void Tick()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1)) 
                ActivateSpell(0);
            if (Input.GetKeyUp(KeyCode.Alpha1)) 
                DeactivateSpell(0);
            
            if (Input.GetKeyDown(KeyCode.Alpha2)) 
                ActivateSpell(1);
            if (Input.GetKeyUp(KeyCode.Alpha2)) 
                DeactivateSpell(1);
            
            if (Input.GetKeyDown(KeyCode.Alpha3))
                ActivateSpell(2);
        }
    }
}