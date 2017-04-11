using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace Battle_Ground.Characters
{
    class Adventurer : Character
    {
        public Adventurer()
        {
            // Sets unique values for the character name, image source, attack, and health.
            _charName = "Adventurer";
            _charImageSource = "ms-appx:///Assets/Adventurer.png";
            _attk = 10;
            _health = 100;
        }

        // Sets the 4 attacks that the player can choose if they have chosen the character "Adventurer"
        public override void Attack1(Player _playerAttackingWithAdventurer, Player _playerAttackedByAdventurer)
        {
            Stab(_playerAttackingWithAdventurer, _playerAttackedByAdventurer);
        }
    }
}
