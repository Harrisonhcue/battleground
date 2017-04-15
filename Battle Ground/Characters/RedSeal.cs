using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battle_Ground.Characters
{
    class RedSeal : Character
    {
        public RedSeal()
        {
            // Sets unique values for the character name, image source, attack, and health.
            _charName = "RedSeal";
            _charImageSource = "ms-appx:///Assets/RedSeal.png";
            _attk = 10;
            _health = 100;
        }

        // Sets the 4 attacks that the player can choose if they have chosen the character "Adventurer"
        public override void Attack1(Player _playerAttackingWithRedSeal, Player _playerAttackedByRedSeal)
        {
            Stab(_playerAttackingWithRedSeal, _playerAttackedByRedSeal);
        }
    }
}
