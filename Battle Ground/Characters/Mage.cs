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
            _attk = 5;
            _spAttack = 25;
            _defense = 10;
            _spDefense = 25;
            _health = 60;
            _attk1Name = "Fireball";
            _attk2Name = "Water Cannon";
            _attk3Name = "Thunder";
            _attk4Name = "Void";
        }

        // Sets the 4 attacks that the player can choose if they have chosen the character "Mage"
        public override void Attack1(Player _playerAttackingWithMage, Player _playerAttackedByMage)
        {
            Fireball(_playerAttackingWithMage, _playerAttackedByMage);
        }
        public override void Attack2(Player _playerAttackingWithMage, Player _playerAttackedByMage)
        {
            WaterCannon(_playerAttackingWithMage, _playerAttackedByMage);
        }
        public override void Attack3(Player _playerAttackingWithMage, Player _playerAttackedByMage)
        {
            Thunder(_playerAttackingWithMage, _playerAttackedByMage);
        }
        public override void Attack4(Player _playerAttackingWithMage, Player _playerAttackedByMage)
        {
            Void(_playerAttackingWithMage, _playerAttackedByMage);
        }
    }
}
