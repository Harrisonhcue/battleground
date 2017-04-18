using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battle_Ground.Characters
{
    /// <summary>
    /// Character type, derives from character class. Written by Sohails
    /// </summary>
    class RedSeal : Character
    {
        public RedSeal()
        {
            // Sets unique values for the character name, image source, attack, special attack, defense, special defense, and health of this character type.
            _charName = "Red Seal";
            _charImageSource = "ms-appx:///Assets/RedSeal.png";
            _attk = 15;
            _spAttack = 5;
            _defense = 20;
            _spDefense = 10;
            _health = 120;

            // Sets the name of the attacks that this character type has access to.
            _attk1Name = "Bite";
            _attk2Name = "Thrash";
            _attk3Name = "Water Cannon";
            _attk4Name = "Void";
        }

        // Sets the 4 attacks that the player can choose if they have chosen the character "RedSeal"
        public override void Attack1(Player _playerAttackingWithRedSeal, Player _playerAttackedByRedSeal)
        {
            Bite(_playerAttackingWithRedSeal, _playerAttackedByRedSeal);
        }
        public override void Attack2(Player _playerAttackingWithRedSeal, Player _playerAttackedByRedSeal)
        {
            Thrash(_playerAttackingWithRedSeal, _playerAttackedByRedSeal);
        }
        public override void Attack3(Player _playerAttackingWithRedSeal, Player _playerAttackedByRedSeal)
        {
            WaterCannon(_playerAttackingWithRedSeal, _playerAttackedByRedSeal);
        }
        public override void Attack4(Player _playerAttackingWithRedSeal, Player _playerAttackedByRedSeal)
        {
            Void(_playerAttackingWithRedSeal, _playerAttackedByRedSeal);
        }
    }
}
