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
            _charName = "Blue Lizard";
            _charImageSource = "ms-appx:///Assets/BlueLizard.png";
            _attk = 8;
            _health = 120;
        }

        // Sets the 4 attacks that the player can choose if they have chosen the character "Blue Lizard"
        public override void Attack1(Player _playerAttackingWithBlueLizard, Player _playerAttackedByBlueLIzard)
        {
            Bite(_playerAttackingWithBlueLizard, _playerAttackedByBlueLIzard);
        }
    }
}
