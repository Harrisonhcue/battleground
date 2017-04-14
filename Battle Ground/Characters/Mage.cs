using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battle_Ground.Characters
{
    class Mage : Character
    {
        public Mage()
        {
            // Sets unique values for the character name, image source, attack, and health.
            _charName = "Mage";
            _charImageSource = "ms-appx:///Assets/Mage.png";
            _attk = 10;
            _health = 100;
        }

        // Sets the 4 attacks that the player can choose if they have chosen the character "Adventurer"
        public override void Attack1(Player _playerAttackingWithMage, Player _playerAttackedByMage)
        {
            Stab(_playerAttackingWithMage, _playerAttackedByMage);
        }
    }
}
