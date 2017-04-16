using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace Battle_Ground.Characters
{
    class BlueLizard : Character
    {
        public BlueLizard()
        {
            // Sets unique values for the character name, image source, attack, special attack, defense, special defense, and health of this character type.
            _charName = "Blue Lizard";
            _charImageSource = "ms-appx:///Assets/BlueLizard.png";
            _attk = 5;
            _spAttack = 8;
            _defense = 20;
            _spDefense = 10;
            _health = 150;

            // Sets the name of the attacks that this character type has access to.
            _attk1Name = "Bite";
            _attk2Name = "Stomp";
            _attk3Name = "Fireball";
            _attk4Name = "Void";
        }

        // Sets the 4 attacks that the player can choose if they have chosen the character "Blue Lizard"
        public override void Attack1(Player _playerAttackingWithBlueLizard, Player _playerAttackedByBlueLIzard)
        {
            Bite(_playerAttackingWithBlueLizard, _playerAttackedByBlueLIzard);
        }
        public override void Attack2(Player _playerAttackingWithBlueLizard, Player _playerAttackedByBlueLIzard)
        {
            Stomp(_playerAttackingWithBlueLizard, _playerAttackedByBlueLIzard);
        }
        public override void Attack3(Player _playerAttackingWithBlueLizard, Player _playerAttackedByBlueLIzard)
        {
            Fireball(_playerAttackingWithBlueLizard, _playerAttackedByBlueLIzard);
        }
        public override void Attack4(Player _playerAttackingWithBlueLizard, Player _playerAttackedByBlueLIzard)
        {
            Thunder(_playerAttackingWithBlueLizard, _playerAttackedByBlueLIzard);
        }
    }
}
