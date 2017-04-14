using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battle_Ground.Characters
{
    class SkeletonKnight : Character
    {
        public SkeletonKnight()
        {
            // Sets unique values for the character name, image source, attack, and health.
            _charName = "Skeleton Knight";
            _charImageSource = "ms-appx:///Assets/Skeleton Knight.png";
            _attk = 10;
            _health = 100;
        }

        // Sets the 4 attacks that the player can choose if they have chosen the character "Adventurer"
        public override void Attack1(Player _playerAttackingWithSkeletonKnight, Player _playerAttackedBySkeletonKnight)
        {
            Stab(_playerAttackingWithSkeletonKnight, _playerAttackedBySkeletonKnight);
        }
    }
}
