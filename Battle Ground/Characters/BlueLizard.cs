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
            // Sets unique values for the character name, image source, attack, and health.
            _charName = "BlueLizard";
            _charImageSource = "ms-appx:///Assets/BlueLizard.png";
            _attk = 9;
            _spAttack = 5;
            _defense = 15;
            _spDefense = 5;
            _health = 150;
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
