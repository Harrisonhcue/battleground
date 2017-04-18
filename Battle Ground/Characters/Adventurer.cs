using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace Battle_Ground.Characters
{
    /// <summary>
    /// Character type, derives from character class. Written by Sohail
    /// </summary>
    class Adventurer : Character
    {
        public Adventurer()
        {
            // Sets unique values for the character name, image source, attack, special attack, defense, special defense, and health of this character type.
            _charName = "Adventurer";
            _charImageSource = "ms-appx:///Assets/Adventurer.png";
            _attk = 15;
            _spAttack = 8;
            _defense = 10;
            _spDefense = 10;
            _health = 100;

            // Sets the name of the attacks that this character type has access to.
            _attk1Name = "Stab";
            _attk2Name = "Slash";
            _attk3Name = "Fireball";
            _attk4Name = "Water Cannon";
        }

        // Sets the 4 attacks that the player can choose if they have chosen the character "Adventurer"
        public override void Attack1(Player _playerAttackingWithAdventurer, Player _playerAttackedByAdventurer)
        {
            Stab(_playerAttackingWithAdventurer, _playerAttackedByAdventurer);
        }
        public override void Attack2(Player _playerAttackingWithAdventurer, Player _playerAttackedByAdventurer)
        {
            Slash(_playerAttackingWithAdventurer, _playerAttackedByAdventurer);
        }
        public override void Attack3(Player _playerAttackingWithAdventurer, Player _playerAttackedByAdventurer)
        {
            Fireball(_playerAttackingWithAdventurer, _playerAttackedByAdventurer);
        }
        public override void Attack4(Player _playerAttackingWithAdventurer, Player _playerAttackedByAdventurer)
        {
            WaterCannon(_playerAttackingWithAdventurer, _playerAttackedByAdventurer);
        }
    }
}
