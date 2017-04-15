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
            _charImageSource = "ms-appx:///Assets/SkeletonKnight.png";
            _attk = 15;
            _spAttack = 8;
            _defense = 8;
            _spDefense = 12;
            _health = 80;
            _attk1Name = "Stab";
            _attk2Name = "Slash";
            _attk3Name = "Void";
            _attk4Name = "Thunder";
        }

        // Sets the 4 attacks that the player can choose if they have chosen the character "SkeletonKnight"
        public override void Attack1(Player _playerAttackingWithSkeletonKnight, Player _playerAttackedBySkeletonKnight)
        {
            Stab(_playerAttackingWithSkeletonKnight, _playerAttackedBySkeletonKnight);
        }
        public override void Attack2(Player _playerAttackingWithSkeletonKnight, Player _playerAttackedBySkeletonKnight)
        {
            Slash(_playerAttackingWithSkeletonKnight, _playerAttackedBySkeletonKnight);
        }
        public override void Attack3(Player _playerAttackingWithSkeletonKnight, Player _playerAttackedBySkeletonKnight)
        {
            Void(_playerAttackingWithSkeletonKnight, _playerAttackedBySkeletonKnight);
        }
        public override void Attack4(Player _playerAttackingWithSkeletonKnight, Player _playerAttackedBySkeletonKnight)
        {
            Thunder(_playerAttackingWithSkeletonKnight, _playerAttackedBySkeletonKnight);
        }
    }
}
