using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace Battle_Ground
{
    class Character
    {
        // Variables that store the character's image source, the character's name, the characters attack, the character's health, and damage the character will deal.
        protected string _charImageSource;
        protected string _charName;
        protected double _attk = 0;
        protected double _health = 0;
        protected double _dmg = 0;

        // Property to allow other classes to access the character image source
        public string CharImageSource
        {
            get
            {
                return _charImageSource;
            }

            set
            {
                _charImageSource = value;
            }
        }

        // Property to allow other classes to access the character name
        public string CharName
        {
            get
            {
                return _charName;
            }

            set
            {
                _charName = value;
            }
        }

        // All attacks available to all characters, take the paramaters of the player that is attacking and the player that is being attacked.
        public void Bite(Player _playerAttacking, Player _playerAttacked)
        {
            _dmg = _playerAttacking.Character._attk * 2;
            _playerAttacked.Character._health -= _dmg;
        }

        public void Stab(Player _playerAttacking, Player _playerAttacked)
        {
            _dmg = _playerAttacking.Character._attk * 1.5;
            _playerAttacked.Character._health -= _dmg;
        }
    }
}
